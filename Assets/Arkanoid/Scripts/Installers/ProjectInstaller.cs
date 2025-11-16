using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "Project Installer", menuName = "Project Installer")]
public class ProjectInstaller : ScriptableObjectInstaller
{
    [SerializeField] private ProjectDescriptor projectDescriptor;

    public override void InstallBindings()
    {
        Container.Bind<ProjectDescriptor>().FromInstance(projectDescriptor).AsSingle();
    }
}