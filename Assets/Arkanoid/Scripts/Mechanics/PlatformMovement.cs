using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class PlatformMovement : IInitializable, IDisposable
{
    private bool isBlockingRight;
    private bool isBlockingLeft;
    private PlatformControls platformControls;
    private float axis;

    public void Initialize()
    {
        platformControls = new PlatformControls();
        platformControls.Enable();
        platformControls.Actions.Movement.started += SetAxis;
        platformControls.Actions.Movement.canceled += ResetAxis;
    }

    public void SetAxis(float value) => axis = value;

    public void Move(Rigidbody rigidbody, float moveSpeed)
    {
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

    private void SetAxis(InputAction.CallbackContext context) => SetAxis(context.ReadValue<float>());
    private void ResetAxis(InputAction.CallbackContext _) => SetAxis(0);

    public void Dispose()
    {
        platformControls.Actions.Movement.started -= SetAxis;
        platformControls.Actions.Movement.canceled -= ResetAxis;
        platformControls.Disable();
        platformControls.Dispose();
    }
}