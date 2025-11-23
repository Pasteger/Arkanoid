using UniRx;

public abstract class BaseUIViewModel : IUIViewModel
{
    protected IUIModel Model = null!;
    protected readonly CompositeDisposable Disposables;

    public Subject<IUIModel> OnInit { get; }
    public Subject<bool> OnActivate { get; }

    protected BaseUIViewModel()
    {
        Disposables = new CompositeDisposable();
        OnInit = new Subject<IUIModel>();
        OnActivate = new Subject<bool>();
    }

    public void SetModel(IUIModel uiModel)
    {
        Model = uiModel;

        Subscribe();
    }

    public void InitView() => OnInit.OnNext(Model);

    protected abstract void Subscribe();

    public void Dispose() => Disposables.Dispose();
}