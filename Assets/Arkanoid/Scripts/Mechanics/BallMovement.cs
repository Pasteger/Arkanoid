using UnityEngine;

public class BallMovement
{
    public void Move(Rigidbody rigidbody, BallModel ballModel) => rigidbody.velocity = ballModel.Direction.Value * ballModel.MoveSpeed.Value;

    public void Collide(Collision other, BallModel ballModel)
    {
        Vector3 normal = other.contacts[0].normal;
        ballModel.Direction.Value = Vector3.Reflect(ballModel.Direction.Value, normal);
    }
}