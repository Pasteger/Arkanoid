using UniRx;

public class MainMenuViewModel : BaseUIViewModel
{
    public Subject<Unit> OnPlay;
    public Subject<Unit> OnExit;

    public MainMenuViewModel() : base()
    {
        OnPlay = new Subject<Unit>();
        OnExit = new Subject<Unit>();
    }

    public void PlayGame() => OnPlay.OnNext(Unit.Default);
    public void ExitGame() => OnExit.OnNext(Unit.Default);

    protected override void Subscribe()
    {
    }
}