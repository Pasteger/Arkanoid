using System;
using MiniIT.INTERACTABLES.VIEWMODEL;
using UnityEngine;

namespace MiniIT.INTERACTABLES.VIEW
{
    public interface IInteractableView : IDisposable
    {
        public IInteractableViewModel ViewModel { get; }
        public void SetViewModel(IInteractableViewModel viewModel);
        public void Activate(bool isActive, Vector3 position = new Vector3());
    }
}