using MiniIT.DESCRIPTORS;
using UnityEngine.SceneManagement;
using Zenject;

namespace MiniIT.BOOTSTRAP
{
    public class Bootstrap : IInitializable
    {
        private readonly ProjectDescriptor projectDescriptor = null;

        [Inject]
        public Bootstrap(ProjectDescriptor projectDescriptor)
        {
            this.projectDescriptor = projectDescriptor;
        }

        public void Initialize()
        {
            SceneManager.LoadScene(projectDescriptor.StartScene);
        }
    }
}