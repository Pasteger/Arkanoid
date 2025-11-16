using UnityEngine.SceneManagement;
using Zenject;

public class Bootstrap : IInitializable
{
    private readonly ProjectDescriptor projectDescriptor;

    [Inject]
    public Bootstrap(ProjectDescriptor projectDescriptor)
    {
        this.projectDescriptor = projectDescriptor;
    }

    public void Initialize() => SceneManager.LoadScene(projectDescriptor.StartScene);
}