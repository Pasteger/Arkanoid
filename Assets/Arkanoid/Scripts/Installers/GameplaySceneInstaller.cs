using UnityEngine;
using Zenject;

public class GameplaySceneInstaller : MonoInstaller
{
    [SerializeField] private LevelsDescriptor levelsDescriptor = null!;
    [SerializeField] private InteractablesPrefabKeysDescriptor interactablesPrefabKeysDescriptor = null!;

    public override void InstallBindings()
    {
        Container.Bind<LevelsDescriptor>().FromInstance(levelsDescriptor).AsSingle();
        Container.Bind<InteractablesPrefabKeysDescriptor>().FromInstance(interactablesPrefabKeysDescriptor).AsSingle();

        Container.BindInterfacesAndSelfTo<InteractablesFactory>().AsSingle();
        Container.BindInterfacesAndSelfTo<PrefabKeyFactory>().AsSingle();

        Container.BindInterfacesAndSelfTo<InteractablesPool>().AsSingle();

        Container.BindInterfacesAndSelfTo<LevelLoader>().AsSingle().NonLazy();
    }
}