using System;
using UnityEngine;

public interface IInteractableViewModel : IDisposable
{
    public InteractableType Type { get; set; }
    public Vector3 Position { get; set; }

    public void SetModel(IInteractableModel model);
    public void Update(Rigidbody2D rigidbody, BoxCollider2D boxCollider, Transform transform);
}