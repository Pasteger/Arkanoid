using System;
using UniRx;
using UnityEngine;

public interface IInteractableViewModel : IDisposable
{
    public InteractableType Type { get; }
    public Vector3 Position { get; }
    public Subject<IInteractableModel> OnSetModel { get; }
    public Subject<bool> OnActivate { get; }

    public void SetModel(IInteractableModel model);
    public void Update(Rigidbody rigidbody);
    public void Collide(Collision other);
}