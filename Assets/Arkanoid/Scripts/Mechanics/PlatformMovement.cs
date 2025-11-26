using System;
using UnityEngine;using Zenject;

public class PlatformMovement : IInitializable, IDisposable
{
    private bool isBlockingRight;
    private bool isBlockingLeft;
    private PlatformControls platformControls;

    public void Initialize()
    {
        platformControls = new PlatformControls();
        platformControls.Enable();
    }
    
    public void Move(Rigidbody rigidbody, float moveSpeed)
    {
        float axis = platformControls.Actions.Movement.ReadValue<float>();

        if (axis > 0 && isBlockingRight || axis < 0 && isBlockingLeft) return;

        if (axis < 0)
        {
            isBlockingRight = false;
        }

        if (axis > 0)
        {
            isBlockingLeft = false;
        }

        rigidbody.velocity = new Vector3(axis * moveSpeed, rigidbody.velocity.y, rigidbody.velocity.z);
    }

    public void Collide(Collision other)
    {
      

        if (other.contacts[0].normal.x < 0)
        {
            isBlockingRight = true;
        }
        else if (other.contacts[0].normal.x > 0)
        {
            isBlockingLeft = true;
        }
    }

    public void Dispose()
    {
        platformControls.Disable();
        platformControls.Dispose();
    }
}