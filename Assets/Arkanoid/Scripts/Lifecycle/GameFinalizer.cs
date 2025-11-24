using System;
using UniRx;
using UnityEngine;
using Zenject;

public class GameFinalizer : IInitializable, IDisposable
{
    public readonly Subject<int> OnFinish = new Subject<int>();
    
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
    
    private void CheckFinal()
    {
        counter++;
        if (counter >= goal)
        {
            OnFinish.OnNext(counter);
        }
    }

    public void Dispose() => compositeDisposable.Dispose();
}