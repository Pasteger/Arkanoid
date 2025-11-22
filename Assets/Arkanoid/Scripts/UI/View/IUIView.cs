using System;

public interface IUIView : IDisposable
{
    public IUIViewModel ViewModel { get; }
    public void SetViewModel(IUIViewModel viewModel);
    public void Activate(bool isActive);
}