using MiniIT.LIFECYCLE;
using MiniIT.MECHANICS;
using MiniIT.UI.MODEL;
using UniRx;
using Zenject;

namespace MiniIT.UI.VIEWMODEL
{
    public class HUDViewModel : BaseUIViewModel
    {
        public readonly ReactiveProperty<int> Score = new ReactiveProperty<int>();

        private LevelLoader levelLoader;
        private BrickDestruction brickDestruction;
        private PlatformMovement platformMovement;

        [Inject]
        public void Construct(LevelLoader loader, BrickDestruction bricksDestruction, PlatformMovement movement)
        {
            levelLoader = loader;
            brickDestruction = bricksDestruction;
            platformMovement = movement;
        }

        protected override void Subscribe()
        {
            HUDModel hudModel = (HUDModel)Model;

            hudModel.Score.Subscribe(score => Score.Value = score).AddTo(Disposables);

            levelLoader.OnLevelLoaded.Subscribe(_ => Init()).AddTo(Disposables);
            brickDestruction.OnBrickDestroyed.Subscribe(_ => Score.Value++).AddTo(Disposables);
        }

        public void MovePlatformRight()
        {
            platformMovement.SetAxis(+1);
        }

        public void MovePlatformLeft()
        {
            platformMovement.SetAxis(-1);
        }

        public void MovePlatformReset()
        {
            platformMovement.SetAxis(0);
        }

        private void Init()
        {
            Score.Value = 0;
            OnActivate.OnNext(true);
        }
    }
}