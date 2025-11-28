using Cysharp.Threading.Tasks;
using MiniIT.DATA;
using MiniIT.DESCRIPTORS;
using MiniIT.ENUM;
using MiniIT.INTERACTABLES.MODEL;
using MiniIT.INTERACTABLES.VIEW;
using Zenject;

namespace MiniIT.LIFECYCLE
{
    public class InteractablesLoader
    {
        private readonly InteractablesPool interactablesPool     = null;
        private readonly LevelsDescriptor  levelsDescriptor      = null;
        private readonly GameFinalizer     gameFinalizer         = null;

        [Inject]
        public InteractablesLoader(
            InteractablesPool interactablesPool,
            LevelsDescriptor levelsDescriptor,
            GameFinalizer gameFinalizer)
        {
            this.interactablesPool  = interactablesPool;
            this.levelsDescriptor   = levelsDescriptor;
            this.gameFinalizer      = gameFinalizer;
        }
        
        public async UniTask LoadAsync(LevelData levelData)
        {
            await interactablesPool.Get(InteractableType.Platform, levelsDescriptor.PlatformPosition);
            await interactablesPool.Get(InteractableType.Ball, levelsDescriptor.BallPosition);

            int breakableBricksCount = 0;

            foreach (BrickModel brickModel in levelData.Bricks)
            {
                IInteractableView brickView = await interactablesPool.Get(InteractableType.Brick, brickModel.Position);

                brickView.ViewModel.SetModel(brickModel);

                if (!brickModel.IsUnbreakable)
                {
                    breakableBricksCount++;
                }
            }

            gameFinalizer.SetLevelGoal(breakableBricksCount);
        }
        
        public void Unload()
        {
            interactablesPool.ReleaseAll();
        }
    }
}