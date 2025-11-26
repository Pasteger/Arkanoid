using System.Collections.Generic;
using UniRx;
using Zenject;

public class GameOverViewModel : BaseUIViewModel
{
    private LevelLoader levelLoader;
    private GameFinalizer gameFinalizer;

    [Inject]
    public void Construct(LevelLoader loader, GameFinalizer finalizer)
    {
        levelLoader = loader;
        gameFinalizer = finalizer;
    }

    public void Restart()
    {
        levelLoader.ReloadLevel();
        OnActivate.OnNext(false);
    }

    protected override void Subscribe()
    {
        gameFinalizer.OnFinish.Subscribe(Activate).AddTo(Disposables);
    }

    private void Activate(KeyValuePair<EndGameType, int> result)
    {
        if (result.Key != EndGameType.Over)
        {
            return;
        }

        OnActivate.OnNext(true);
    }
}