using UniRx;
using UnityEngine;
using Zenject;

public class PlatformViewModel : BaseInteractableViewModel
{
    private PlatformMovement platformMovement;
    private GameFinalizer gameFinalizer;

    private PlatformModel platformModel => (PlatformModel)Model;

    [Inject]
    public void Construct(PlatformMovement movement, GameFinalizer finalizer)
    {
        platformMovement = movement;
        gameFinalizer = finalizer;

        gameFinalizer.OnFinish.Subscribe(_ => OnActivate.OnNext(false)).AddTo(Disposables);
    }

    public override void Update(Rigidbody rigidbody) => platformMovement.Move(rigidbody, platformModel.MoveSpeed.Value);

    public override void Collide(Collision other)
    {
        if ((platformModel.BallLayer & (1 << other.gameObject.layer)) != 0) return; 
        
        platformMovement.Collide(other);
    }
}