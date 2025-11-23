using Doozy.Runtime.UIManager.Containers;
using UniRx;
using UnityEngine;

public abstract class BaseUIView : MonoBehaviour, IUIView
{
    public IUIViewModel ViewModel { get; private set; } = null!;
    protected readonly CompositeDisposable Disposables = new CompositeDisposable();
    protected UIView UIView = null!;

    public void SetViewModel(IUIViewModel viewModel)
    {
        ViewModel = viewModel;

        Disposables.Add(ViewModel);

        Subscribe();
    }

    protected virtual void Awake() => UIView = GetComponent<UIView>();

    protected virtual void Start() => ViewModel.InitView();

    public virtual void Activate(bool isActive)
    {
        if (isActive)
        {
            UIView.Show();
        }
        else
        {
            UIView.Hide();
        }
    }

    public virtual void SetParent(Transform parent) => transform.SetParent(parent);

    protected abstract void Init(IUIModel uiModel);
    protected virtual void Subscribe()
    {
        ViewModel.OnInit.Subscribe(Init).AddTo(Disposables);
        ViewModel.OnActivate.Subscribe(Activate).AddTo(Disposables);
    }

    protected void OnDestroy() => Dispose();

    public virtual void Dispose() => Disposables.Dispose();
}