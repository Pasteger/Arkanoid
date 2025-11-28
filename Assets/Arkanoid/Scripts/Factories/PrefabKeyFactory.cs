using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace MiniIT.FACTORIES
{
    public class PrefabKeyFactory
    {
        private readonly DiContainer                                      diContainer     = null;

        private readonly Dictionary<string, GameObject>                   prefabs         = null;
        private readonly Dictionary<string, UniTask<GameObject>>          loadingTasks    = null;

        [Inject]
        public PrefabKeyFactory(DiContainer diContainer)
        {
            this.diContainer = diContainer;

            prefabs      = new Dictionary<string, GameObject>();
            loadingTasks = new Dictionary<string, UniTask<GameObject>>();
        }
        
        public async UniTask<T> Create<T>(string prefabKey) where T : class
        {
            GameObject prefab = await GetOrLoadPrefabAsync(prefabKey);

            GameObject instance = diContainer.InstantiatePrefab(prefab);

            return instance.GetComponent<T>();
        }

        private UniTask<GameObject> GetOrLoadPrefabAsync(string key)
        {
            if (prefabs.TryGetValue(key, out GameObject cachedPrefab))
            {
                return UniTask.FromResult(cachedPrefab);
            }

            if (loadingTasks.TryGetValue(key, out UniTask<GameObject> existingTask))
            {
                return existingTask;
            }

            UniTask<GameObject> loadingTask = LoadAndCacheAsync(key);
            loadingTasks[key] = loadingTask;

            return loadingTask;
        }
        
        private async UniTask<GameObject> LoadAndCacheAsync(string key)
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
}