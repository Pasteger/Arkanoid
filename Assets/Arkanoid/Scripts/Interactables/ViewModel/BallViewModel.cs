using UnityEngine;
using Zenject;

public class BallViewModel : InteractableViewModel
{
    private BallMovement ballMovement;
    private BallModel ballModel => (BallModel)Model;

    [Inject]
    public void Construct(BallMovement movement) => ballMovement = movement;

    public override void Update(Rigidbody rigidbody) => ballMovement.Move(rigidbody, ballModel);
    public override void Collide(Collision other) => ballMovement.Collide(other, ballModel);
}