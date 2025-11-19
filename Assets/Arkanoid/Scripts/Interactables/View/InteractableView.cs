using UniRx;
using UnityEngine;

public class InteractableView : MonoBehaviour, IInteractableView
{
    public IInteractableViewModel ViewModel { get; private set; } = null!;

    protected readonly CompositeDisposable Disposable = new CompositeDisposable();

    public void SetViewModel(IInteractableViewModel viewModel)
    {
        ViewModel = viewModel;
        Disposable.Add(ViewModel);
    }

    public void Activate(bool isActive, Vector3 position = new Vector3())
    {
        gameObject.SetActive(isActive);
        transform.position = position;
    }

    protected void OnDestroy() => Dispose();

    public void Dispose() => Disposable.Dispose();
}