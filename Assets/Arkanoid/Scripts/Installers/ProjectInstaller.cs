using MiniIT.BOOTSTRAP;
using MiniIT.DESCRIPTORS;
using UnityEngine;
using Zenject;

namespace MiniIT.INSTALLERS
{
    [CreateAssetMenu(fileName = "Project Installer", menuName = "Project Installer")]
    public class ProjectInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private ProjectDescriptor projectDescriptor = null!;

        public override void InstallBindings()
        {
            Container.Bind<ProjectDescriptor>()
                .FromInstance(projectDescriptor)
                .AsSingle();

            Container.BindInterfacesAndSelfTo<Bootstrap>()
                .AsSingle()
                .NonLazy();
        }
    }
}