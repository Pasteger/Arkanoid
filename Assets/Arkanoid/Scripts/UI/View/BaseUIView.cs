using UniRx;
using UnityEngine;

public abstract class BaseUIView : MonoBehaviour, IUIView
{
    public IUIViewModel ViewModel { get; private set; } = null!;
    protected readonly CompositeDisposable Disposables = new CompositeDisposable();

    public void SetViewModel(IUIViewModel viewModel)
    {
        ViewModel = viewModel;
        
        Disposables.Add(ViewModel);
        
        Subscribe();
    }

    protected void Start() => ViewModel.InitView();

    public virtual void Activate(bool isActive) => gameObject.SetActive(isActive);

    protected abstract void Init(IUIModel uiModel);
    protected virtual void Subscribe() => ViewModel.OnInit.Subscribe(Init).AddTo(Disposables);

    protected void OnDestroy() => Dispose();

    public void Dispose() => Disposables.Dispose();
}