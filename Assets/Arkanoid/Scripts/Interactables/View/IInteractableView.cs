using System;
using UnityEngine;

public interface IInteractableView : IDisposable
{
    public IInteractableViewModel ViewModel { get; }
    public void SetViewModel(IInteractableViewModel viewModel);
    public void Activate(bool isActive, Vector3 position = new Vector3());
}