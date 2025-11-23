using Cysharp.Threading.Tasks;
using Zenject;

public class MainMenuViewModel : BaseUIViewModel
{
    private LevelLoader levelLoader;
    private GameExit gameExit;

    [Inject]
    public void Construct(LevelLoader loader, GameExit exit)
    {
        levelLoader = loader;
        gameExit = exit;
    }

    public void PlayGame()
    {
        levelLoader.LoadLevel().Forget();
        OnActivate.OnNext(false);
    }

    public void ExitGame() => gameExit.Exit();

    protected override void Subscribe()
    {
    }
}