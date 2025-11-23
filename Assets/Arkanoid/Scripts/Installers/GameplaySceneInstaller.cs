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

        Container.Bind<InteractablesFactory>().AsSingle();
        Container.Bind<UIFactory>().AsSingle();
        Container.Bind<PrefabKeyFactory>().AsSingle();

        Container.Bind<InteractablesPool>().AsSingle();

        Container.Bind<InteractablesLoader>().AsSingle();
        Container.BindInterfacesAndSelfTo<LevelLoader>().AsSingle();
        Container.BindInterfacesAndSelfTo<GameExit>().AsSingle();

        Container.BindInterfacesAndSelfTo<UILoader>().AsSingle().NonLazy();
    }
}