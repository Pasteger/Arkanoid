using UniRx;
using UnityEngine;
using Zenject;

public class BallViewModel : BaseInteractableViewModel
{
    private BallMovement ballMovement;
    private GameFinalizer gameFinalizer;
    private AudioService audioService;

    private Vector3 DefaultDirection;

    private BallModel ballModel => (BallModel)Model;

    [Inject]
    public void Construct(BallMovement movement, GameFinalizer finalizer, AudioService audios)
    {
        ballMovement = movement;
        gameFinalizer = finalizer;
        audioService = audios;

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
        if ((ballModel.DeathTriggerLayer & (1 << other.gameObject.layer)) != 0)
        {
            OnActivate.OnNext(false);
            gameFinalizer.GameOver();
        }
        else
        {
            ballMovement.Collide(other, ballModel);
            audioService.PlaySound(SoundName.BallCollide);
        }
    }

    private void Deactivate()
    {
        OnActivate.OnNext(false);
        ballModel.Direction.Value = DefaultDirection;
    }
}