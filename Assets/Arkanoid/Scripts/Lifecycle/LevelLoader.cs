using Cysharp.Threading.Tasks;
using MiniIT.DATA;
using MiniIT.DESCRIPTORS;
using MiniIT.FACTORIES;
using UniRx;
using UnityEngine;
using Zenject;

namespace MiniIT.LIFECYCLE
{
    public class LevelLoader
    {
        public Subject<Unit> OnLevelLoaded { get; } = new Subject<Unit>();

        private readonly LevelsDescriptor      levelsDescriptor     = null;
        private readonly PrefabKeyFactory      prefabKeyFactory     = null;
        private readonly InteractablesLoader   interactablesLoader  = null;

        private LevelData currentLevelData = null;
        private Transform border           = null;

        [Inject]
        public LevelLoader(
            LevelsDescriptor levelsDescriptor,
            PrefabKeyFactory prefabKeyFactory,
            InteractablesLoader interactablesLoader)
        {
            this.levelsDescriptor    = levelsDescriptor;
            this.prefabKeyFactory    = prefabKeyFactory;
            this.interactablesLoader = interactablesLoader;
        }

        public async UniTask LoadLevelAsync()
        {
            string levelName = PlayerPrefs.GetString("CurrentLevel", string.Empty);
            currentLevelData = levelsDescriptor.GetLevel(levelName);

            await EnsureBorderCreatedAsync();

            border.gameObject.SetActive(true);

            await interactablesLoader.LoadAsync(currentLevelData);

            OnLevelLoaded.OnNext(Unit.Default);
        }

        public void CompleteLevel()
        {
            PlayerPrefs.SetString("CurrentLevel", currentLevelData.NextLevelName);
            ReloadLevel();
        }

        public void ReloadLevel()
        {
            UnloadLevel();
            LoadLevelAsync().Forget();
        }
        
        private void UnloadLevel()
        {
            if (border != null)
            {
                border.gameObject.SetActive(false);
            }

            interactablesLoader.Unload();
        }
        
        private async UniTask EnsureBorderCreatedAsync()
        {
            if (border == null)
            {
                border = await prefabKeyFactory.Create<Transform>(levelsDescriptor.BorderPrefabKey);
            }
        }
    }
}