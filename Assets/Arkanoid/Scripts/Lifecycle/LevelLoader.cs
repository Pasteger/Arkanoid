using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class LevelLoader : IInitializable
{
    private LevelsDescriptor levelsDescriptor = null!;
    private InteractablesPool interactablesPool = null!;
    private PrefabKeyFactory prefabKeyFactory = null!;

    private LevelData currentLevelData = null!;
    private Transform border = null!;

    [Inject]
    public void Construct(LevelsDescriptor descriptor, InteractablesPool pool, PrefabKeyFactory keyFactory)
    {
        levelsDescriptor = descriptor;
        interactablesPool = pool;
        prefabKeyFactory = keyFactory;
    }

    public void Initialize() => LoadLevel().Forget();

    public async UniTask LoadLevel()
    {
        string levelName = PlayerPrefs.GetString("CurrentLevel", string.Empty);

        currentLevelData = levelsDescriptor.GetLevel(levelName);

        if (border == null)
        {
            border = await prefabKeyFactory.Create<Transform>(levelsDescriptor.BorderPrefabKey);
        }
        
        border.gameObject.SetActive(true);

        await interactablesPool.Get(InteractableType.Platform, levelsDescriptor.PlatformPosition);
        await interactablesPool.Get(InteractableType.Ball, levelsDescriptor.BallPosition);

        foreach (BrickModel brickModel in currentLevelData.Bricks)
        {
            IInteractableView brick = await interactablesPool.Get(InteractableType.Brick, brickModel.Position);
            brick.ViewModel.SetModel(brickModel);
        }
    }

    public void UnloadLevel()
    {
        border.gameObject.SetActive(false);

        interactablesPool.ReleaseAll();
    }

    public void CompleteLevel()
    {
        PlayerPrefs.SetString("CurrentLevel", currentLevelData.NextLevelName);
        UnloadLevel();
        LoadLevel().Forget();
    }
}