using Cysharp.Threading.Tasks;

public class InteractablesLoader
{
    private readonly InteractablesPool interactablesPool;
    private readonly LevelsDescriptor levelsDescriptor;
    private readonly GameFinalizer gameFinalizer;

    public InteractablesLoader(InteractablesPool pool, LevelsDescriptor descriptor, GameFinalizer finalizer)
    {
        interactablesPool = pool;
        levelsDescriptor = descriptor;
        gameFinalizer = finalizer;
    }

    public async UniTask Load(LevelData levelData)
    {
        await interactablesPool.Get(InteractableType.Platform, levelsDescriptor.PlatformPosition);
        await interactablesPool.Get(InteractableType.Ball, levelsDescriptor.BallPosition);

        int count = 0;
        foreach (BrickModel brickModel in levelData.Bricks)
        {
            IInteractableView brick = await interactablesPool.Get(InteractableType.Brick, brickModel.Position);
            brick.ViewModel.SetModel(brickModel);
            if (!brickModel.IsUnbreakable)
            {
                count++;
            }
        }

        gameFinalizer.SetLevelGoal(count);
    }

    public void Unload() => interactablesPool.ReleaseAll();
}