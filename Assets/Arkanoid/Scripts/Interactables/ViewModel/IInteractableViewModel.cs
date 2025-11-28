using System;
using MiniIT.ENUM;
using MiniIT.INTERACTABLES.MODEL;
using UniRx;
using UnityEngine;

namespace MiniIT.INTERACTABLES.VIEWMODEL
{
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
}