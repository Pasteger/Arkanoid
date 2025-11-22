using UnityEngine;

public class BallMovement
{
    private Vector3 direction;
    private float moveSpeed;

    public BallMovement(Vector3 direction, float moveSpeed)
    {
        this.direction = direction;
        this.moveSpeed = moveSpeed;
    }

    public void Move(Rigidbody rigidbody) => rigidbody.velocity = direction * moveSpeed;

    public void Collide(Collision other)
    {
        Vector3 normal = other.contacts[0].normal;
        direction = Vector3.Reflect(direction, normal);
    }
}