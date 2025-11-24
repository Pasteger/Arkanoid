using UniRx;
using UnityEngine;
using Zenject;

public class EndGameViewModel : BaseUIViewModel
{
    public readonly ReactiveProperty<int> Score = new ReactiveProperty<int>();

    private LevelLoader levelLoader;
    private GameExit gameExit;
    private GameFinalizer gameFinalizer;

    [Inject]
    public void Construct(LevelLoader loader, GameExit exit, GameFinalizer finalizer)
    {
        levelLoader = loader;
        gameExit = exit;
        gameFinalizer = finalizer;
    }

    public void NextLevel()
    {
        levelLoader.CompleteLevel();
        OnActivate.OnNext(false);
    }

    public void ExitGame() => gameExit.Exit();

    protected override void Subscribe()
    {
        EndGameModel endGameModel = (EndGameModel)Model;

        endGameModel.Score.Subscribe(score => Score.Value = score).AddTo(Disposables);
        gameFinalizer.OnFinish.Subscribe(Activate).AddTo(Disposables);
    }

    private void Activate(int score)
    {
        Score.Value = score;
        OnActivate.OnNext(true);
    }
}