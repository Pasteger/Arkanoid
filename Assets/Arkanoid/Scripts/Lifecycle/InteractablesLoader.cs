using Cysharp.Threading.Tasks;

public class InteractablesLoader
{
    private readonly InteractablesPool interactablesPool;
    private readonly LevelsDescriptor levelsDescriptor;

    public InteractablesLoader(InteractablesPool pool, LevelsDescriptor descriptor)
    {
        interactablesPool = pool;
        levelsDescriptor = descriptor;
    }

    public async UniTask Load(LevelData levelData)
    {
        await interactablesPool.Get(InteractableType.Platform, levelsDescriptor.PlatformPosition);
        await interactablesPool.Get(InteractableType.Ball, levelsDescriptor.BallPosition);

        foreach (BrickModel brickModel in levelData.Bricks)
        {
            IInteractableView brick = await interactablesPool.Get(InteractableType.Brick, brickModel.Position);
            brick.ViewModel.SetModel(brickModel);
        }
    }
    
    public void Unload() => interactablesPool.ReleaseAll();
}
