using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class LevelLoader
{
    private readonly LevelsDescriptor levelsDescriptor;
    private readonly PrefabKeyFactory prefabKeyFactory;
    private readonly InteractablesLoader interactablesLoader;

    private LevelData currentLevelData = null!;
    private Transform border = null!;

    [Inject]
    public LevelLoader(
        LevelsDescriptor descriptor,
        PrefabKeyFactory keyFactory,
        InteractablesLoader loaderInteractables)
    {
        levelsDescriptor = descriptor;
        prefabKeyFactory = keyFactory;
        interactablesLoader = loaderInteractables;
    }

    public async UniTask LoadLevel()
    {
        string levelName = PlayerPrefs.GetString("CurrentLevel", string.Empty);
        currentLevelData = levelsDescriptor.GetLevel(levelName);

        if (border == null)
        {
            border = await prefabKeyFactory.Create<Transform>(levelsDescriptor.BorderPrefabKey);
        }

        border.gameObject.SetActive(true);

        await interactablesLoader.Load(currentLevelData);
    }

    private void UnloadLevel()
    {
        border.gameObject.SetActive(false);

        interactablesLoader.Unload();
    }

    public void CompleteLevel()
    {
        PlayerPrefs.SetString("CurrentLevel", currentLevelData.NextLevelName);
        UnloadLevel();
        LoadLevel().Forget();
    }
}