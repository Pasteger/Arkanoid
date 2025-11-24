using UnityEngine;
using Zenject;

public class PlatformViewModel : InteractableViewModel
{
    private PlatformMovement platformMovement;
    private PlatformModel platformModel => (PlatformModel)Model;

    [Inject]
    public void Construct(PlatformMovement movement) => platformMovement = movement;
    
    public override void Update(Rigidbody rigidbody) => platformMovement.Move(rigidbody, platformModel.MoveSpeed.Value);
    public override void Collide(Collision other) => platformMovement.Collide(other);
}