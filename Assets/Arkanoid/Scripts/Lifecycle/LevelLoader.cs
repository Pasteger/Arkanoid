using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class LevelLoader : IInitializable
{
    private LevelsDescriptor    levelsDescriptor = null!;
    private LevelFactory        levelFactory = null!;

    private LevelData           currentLevelData = null!;
    private GameObject          currentLevel = null!;

    [Inject]
    public void Construct(LevelsDescriptor descriptor, LevelFactory factory)
    {
        levelsDescriptor = descriptor;
        levelFactory = factory;
    }

    public void Initialize() => LoadLevel().Forget();

    public async UniTask LoadLevel()
    {
        string levelName = PlayerPrefs.GetString("CurrentLevel", string.Empty);

        currentLevelData = levelsDescriptor.GetLevel(levelName);

        currentLevel = await levelFactory.Create(currentLevelData);
    }

    public void UnloadLevel()
    {
        Object.Destroy(currentLevel);

        currentLevel = null;
    }

    public void CompleteLevel()
    {
        PlayerPrefs.SetString("CurrentLevel", currentLevelData.NextLevelName);
        UnloadLevel();
        LoadLevel().Forget();
    }
}