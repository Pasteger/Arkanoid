using System;
using System.Collections.Generic;
using MiniIT.ENUM;
using MiniIT.MECHANICS;
using UniRx;
using Zenject;

namespace MiniIT.LIFECYCLE
{
    public class GameFinalizer : IInitializable, IDisposable
    {
        public readonly Subject<KeyValuePair<EndGameType, int>> OnFinish = new Subject<KeyValuePair<EndGameType, int>>();

        private readonly BrickDestruction       brickDestruction        = null;
        private readonly CompositeDisposable    compositeDisposable     = null;

        private int counter = 0;
        private int goal    = 0;

        [Inject]
        public GameFinalizer(BrickDestruction brickDestruction)
        {
            this.brickDestruction   = brickDestruction;
            this.compositeDisposable = new CompositeDisposable();
        }

        public void Initialize()
        {
            brickDestruction.OnBrickDestroyed
                             .Subscribe(_ => CheckFinal())
                             .AddTo(compositeDisposable);
        }
        
        public void SetLevelGoal(int count)
        {
            counter = 0;
            goal    = count;
        }
        
        public void GameOver()
        {
            OnFinish.OnNext(new KeyValuePair<EndGameType, int>(EndGameType.Over, 0));
        }
        
        private void CheckFinal()
        {
            counter++;

            if (counter >= goal)
            {
                OnFinish.OnNext(new KeyValuePair<EndGameType, int>(EndGameType.Win, counter));
            }
        }

        public void Dispose()
        {
            compositeDisposable.Dispose();
        }
    }
}