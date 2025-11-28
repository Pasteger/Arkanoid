using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace MiniIT.MECHANICS
{
    public class PlatformMovement : IInitializable, IDisposable
    {
        private bool isBlockingLeft  = false;
        private bool isBlockingRight = false;

        private PlatformControls platformControls = null;
        private float            movementAxis     = 0f;

        public void Initialize()
        {
            platformControls = new PlatformControls();
            platformControls.Enable();

            platformControls.Actions.Movement.started  += OnMovementStarted;
            platformControls.Actions.Movement.canceled += OnMovementCanceled;
        }

        public void SetAxis(float value) => movementAxis = value;
        
        public void Move(Rigidbody rigidbody, float moveSpeed)
        {
            if (rigidbody == null)
            {
                return;
            }

            if ((movementAxis > 0f && isBlockingRight) || 
                (movementAxis < 0f && isBlockingLeft))
            {
                movementAxis = 0f;
            }

            Vector3 velocity = rigidbody.velocity;
            velocity.x = movementAxis * moveSpeed;

            rigidbody.velocity = velocity;
        }
        
        public void Collide(Collision collision)
        {
            if (collision == null || collision.contacts.Length == 0)
            {
                return;
            }

            float normalX = collision.contacts[0].normal.x;

            if (normalX > 0.9f)
            {
                isBlockingLeft  = true;
            }
            else if (normalX < -0.9f)
            {
                isBlockingRight = true;
            }
        }

        public void ReleaseBlock()
        {
            if (movementAxis < 0f)
            {
                isBlockingRight = false;
            }
            else if (movementAxis > 0f)
            {
                isBlockingLeft = false;
            }
        }

        private void OnMovementStarted(InputAction.CallbackContext context)
        {
            movementAxis = context.ReadValue<float>();
            ReleaseBlock();
        }

        private void OnMovementCanceled(InputAction.CallbackContext _)
        {
            movementAxis = 0f;
        }
        
        public void Dispose()
        {
            if (platformControls != null)
            {
                platformControls.Actions.Movement.started  -= OnMovementStarted;
                platformControls.Actions.Movement.canceled -= OnMovementCanceled;

                platformControls.Disable();
                platformControls.Dispose();

                platformControls = null;
            }
        }
    }
}