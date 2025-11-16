using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

public class LevelFactory
{
    private readonly DiContainer   diContainer = null;
    private GameObject             prefab = null;

    [Inject]
    public LevelFactory(DiContainer container) => diContainer = container;

    private async UniTask LoadPrefab(string levelName) =>
        prefab = await Addressables.LoadAssetAsync<GameObject>(levelName);

    public async UniTask<GameObject> Create(LevelData currentLevelData)
    {
        if (prefab == null)
        {
            await LoadPrefab(currentLevelData.LevelName);
        }

        return diContainer.InstantiatePrefab(prefab);
    }
}