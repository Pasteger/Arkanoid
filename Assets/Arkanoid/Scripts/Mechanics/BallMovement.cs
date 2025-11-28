using MiniIT.INTERACTABLES.MODEL;
using UnityEngine;

namespace MiniIT.MECHANICS
{
    public class BallMovement
    {
        public void Move(Rigidbody rigidbody, BallModel ballModel)
        {
            if (rigidbody == null || ballModel == null)
            {
                return;
            }

            rigidbody.velocity = ballModel.Direction.Value * ballModel.MoveSpeed.Value;
        }
        
        public void Collide(Collision collision, BallModel ballModel)
        {
            if (collision == null || ballModel == null || collision.contacts.Length == 0)
            {
                return;
            }

            Vector3 normal = collision.contacts[0].normal;

            ballModel.Direction.Value = Vector3.Reflect(ballModel.Direction.Value, normal);
        }
    }
}