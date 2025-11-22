using UnityEngine;
using Zenject;

public class GameplaySceneInstaller : MonoInstaller
{
    [SerializeField] private LevelsDescriptor levelsDescriptor = null!;
    [SerializeField] private InteractablesDescriptor interactablesDescriptor = null!;
    [SerializeField] private UIModelsDescriptor uiModelsDescriptor = null!;

    public override void InstallBindings()
    {
        Container.Bind<LevelsDescriptor>().FromInstance(levelsDescriptor).AsSingle();
        Container.Bind<InteractablesDescriptor>().FromInstance(interactablesDescriptor).AsSingle();
        Container.Bind<UIModelsDescriptor>().FromInstance(uiModelsDescriptor).AsSingle();

        Container.BindInterfacesAndSelfTo<InteractablesFactory>().AsSingle();
        Container.BindInterfacesAndSelfTo<PrefabKeyFactory>().AsSingle();

        Container.BindInterfacesAndSelfTo<InteractablesPool>().AsSingle();

        Container.BindInterfacesAndSelfTo<LevelLoader>().AsSingle().NonLazy();
    }
}