using UnityEngine;

public class BallViewModel : InteractableViewModel
{
    private readonly BallMovement ballMovement;

    public BallViewModel(BallMovement ballMovement) => this.ballMovement = ballMovement;

    public override void Update(Rigidbody rigidbody) => ballMovement.Move(rigidbody);
    public override void Collide(Collision other) => ballMovement.Collide(other);
}