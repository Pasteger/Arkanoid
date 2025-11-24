using UniRx;
using UnityEngine;
using Zenject;

public class BallViewModel : BaseInteractableViewModel
{
    private BallMovement ballMovement;
    private GameFinalizer gameFinalizer;
    
    private BallModel ballModel => (BallModel)Model;

    [Inject]
    public void Construct(BallMovement movement, GameFinalizer finalizer)
    {
        ballMovement = movement;
        gameFinalizer = finalizer;
        
        gameFinalizer.OnFinish.Subscribe(_ => OnActivate.OnNext(false)).AddTo(Disposables);
    }

    public override void Update(Rigidbody rigidbody) => ballMovement.Move(rigidbody, ballModel);
    public override void Collide(Collision other) => ballMovement.Collide(other, ballModel);
}