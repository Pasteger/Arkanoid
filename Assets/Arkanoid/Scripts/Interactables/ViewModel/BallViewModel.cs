using UniRx;
using UnityEngine;
using Zenject;

public class BallViewModel : BaseInteractableViewModel
{
    private BallMovement ballMovement;
    private GameFinalizer gameFinalizer;

    private Vector3 DefaultDirection;

    private BallModel ballModel => (BallModel)Model;

    [Inject]
    public void Construct(BallMovement movement, GameFinalizer finalizer)
    {
        ballMovement = movement;
        gameFinalizer = finalizer;

        gameFinalizer.OnFinish.Subscribe(_ => Deactivate()).AddTo(Disposables);
    }

    public override void SetModel(IInteractableModel model)
    {
        base.SetModel(model);
        DefaultDirection = ballModel.Direction.Value;
    }

    public override void Update(Rigidbody rigidbody) => ballMovement.Move(rigidbody, ballModel);

    public override void Collide(Collision other)
    {
        if (other.gameObject.layer == ballModel.DeathTriggerLayer)
        {
            OnActivate.OnNext(false);
            gameFinalizer.GameOver();
        }
        else
        {
            ballMovement.Collide(other, ballModel);
        }
    }

    private void Deactivate()
    {
        OnActivate.OnNext(false);
        ballModel.Direction.Value = DefaultDirection;
    }
}