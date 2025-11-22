using UnityEngine;

public class PlatformViewModel : InteractableViewModel
{
    private readonly PlatformMovement platformMovement;

    public PlatformViewModel(PlatformMovement platformMovement)
    {
        this.platformMovement = platformMovement;
        Disposables.Add(platformMovement);
    }

    public PlatformViewModel(PlatformViewModel referenceViewModel) : base(referenceViewModel)
    {
    }
    
    public override void Update(Rigidbody rigidbody) => platformMovement.Move(rigidbody);
    public override void Collide(Collision other) => platformMovement.Collide(other);
}