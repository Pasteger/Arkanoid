using System;
using UnityEngine;

public class PlatformMovement : IDisposable
{
    private bool isBlockingRight;
    private bool isBlockingLeft;
    private float moveSpeed;
    private readonly PlatformControls platformControls;

    public PlatformMovement(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
        platformControls = new PlatformControls();
        platformControls.Enable();
    }

    public void Move(Rigidbody rigidbody)
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
        if (other.gameObject.layer == LayerMask.NameToLayer("Ball")) return;

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