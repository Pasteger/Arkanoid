using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

public class PrefabKeyFactory
{
    private readonly DiContainer                             diContainer;
    private readonly Dictionary<string, GameObject>          prefabs;
    private readonly Dictionary<string, UniTask<GameObject>> loadingTasks;

    [Inject]
    public PrefabKeyFactory(DiContainer container)
    {
        diContainer = container;

        prefabs = new Dictionary<string, GameObject>();
        loadingTasks = new Dictionary<string, UniTask<GameObject>>();
    }

    public async UniTask<T> Create<T>(string prefabKey)
    {
        GameObject prefab = await GetOrLoadPrefab(prefabKey);
        return diContainer.InstantiatePrefab(prefab).GetComponent<T>();
    }

    private UniTask<GameObject> GetOrLoadPrefab(string key)
    {
        if (prefabs.TryGetValue(key, out GameObject prefab))
            return UniTask.FromResult(prefab);

        if (loadingTasks.TryGetValue(key, out UniTask<GameObject> existingTask))
            return existingTask;

        UniTask<GameObject> task = LoadAndCache(key);
        loadingTasks[key] = task;

        return task;
    }

    private async UniTask<GameObject> LoadAndCache(string key)
    {
        try
        {
            GameObject prefab = await Addressables.LoadAssetAsync<GameObject>(key);

            prefabs[key] = prefab;
            return prefab;
        }
        finally
        {
            loadingTasks.Remove(key);
        }
    }
}