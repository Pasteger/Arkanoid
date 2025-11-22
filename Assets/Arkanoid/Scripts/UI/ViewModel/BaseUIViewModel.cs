using UniRx;

public abstract class BaseUIViewModel : IUIViewModel
{
    protected IUIModel Model = null!;
    protected readonly CompositeDisposable Disposables;

    public Subject<IUIModel> OnInit { get; private set; }

    protected BaseUIViewModel()
    {
        Disposables = new CompositeDisposable();
        OnInit = new Subject<IUIModel>();
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