using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class GameFinalizer : IInitializable, IDisposable
{
    public readonly Subject<KeyValuePair<EndGameType, int>> OnFinish = new Subject<KeyValuePair<EndGameType, int>>();
    
    private readonly BrickDestruction brickDestruction;
    private readonly CompositeDisposable compositeDisposable;

    private int counter;
    private int goal;
    
    public GameFinalizer(BrickDestruction bricksDestruction)
    {
        brickDestruction = bricksDestruction;
        compositeDisposable = new CompositeDisposable();
    }

    public void Initialize() => 
        brickDestruction.OnBrickDestroyed.Subscribe(_ => CheckFinal()).AddTo(compositeDisposable);

    public void SetLevelGoal(int count)
    {
        counter = 0;
        goal = count;
    }

    public void GameOver() => OnFinish.OnNext(new KeyValuePair<EndGameType, int>(EndGameType.Over, 0));

    private void CheckFinal()
    {
        counter++;
        if (counter >= goal)
        {
            OnFinish.OnNext(new KeyValuePair<EndGameType, int>(EndGameType.Win, counter));
        }
    }

    public void Dispose() => compositeDisposable.Dispose();
}