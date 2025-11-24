using UniRx;
using UnityEngine;
using Zenject;

public class HUDViewModel : BaseUIViewModel
{
    public readonly ReactiveProperty<int> Score = new ReactiveProperty<int>();

    private LevelLoader levelLoader;
    private BrickDestruction brickDestruction;

    [Inject]
    public void Construct(LevelLoader loader, BrickDestruction bricksDestruction)
    {
        levelLoader = loader;
        brickDestruction = bricksDestruction;
    }

    protected override void Subscribe()
    {
        HUDModel hudModel = (HUDModel)Model;

        hudModel.Score.Subscribe(score => Score.Value = score).AddTo(Disposables);
        
        levelLoader.OnLevelLoaded.Subscribe(_ => Init()).AddTo(Disposables);
        brickDestruction.OnBrickDestroyed.Subscribe(_ => Score.Value++).AddTo(Disposables);
    }

    private void Init()
    {
        Score.Value = 0;
        OnActivate.OnNext(true);
    }
}