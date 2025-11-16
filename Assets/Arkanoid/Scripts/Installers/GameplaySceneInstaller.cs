using UnityEngine;
using Zenject;

public class GameplaySceneInstaller : MonoInstaller
{
    [SerializeField] private LevelsDescriptor levelsDescriptor = null!;

    public override void InstallBindings()
    {
        Container.Bind<LevelsDescriptor>().FromInstance(levelsDescriptor).AsSingle();

        Container.BindInterfacesAndSelfTo<LevelLoader>().AsSingle().NonLazy();

        Container.BindInterfacesAndSelfTo<LevelFactory>().AsSingle();
    }
}