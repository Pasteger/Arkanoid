using System.Collections.Generic;
using UniRx;
using Zenject;

public class EndGameViewModel : BaseUIViewModel
{
    public readonly ReactiveProperty<int> Score = new ReactiveProperty<int>();

    private LevelLoader levelLoader;
    private GameExit gameExit;
    private GameFinalizer gameFinalizer;
    private AudioService audioService;

    [Inject]
    public void Construct(LevelLoader loader, GameExit exit, GameFinalizer finalizer, AudioService audios)
    {
        levelLoader = loader;
        gameExit = exit;
        gameFinalizer = finalizer;
        audioService = audios;
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

    private void Activate(KeyValuePair<EndGameType, int> result)
    {
        if (result.Key != EndGameType.Win)
        {
            return;
        }

        Score.Value = result.Value;
        OnActivate.OnNext(true);
        audioService.PlaySound(SoundName.GameWin);
    }
}