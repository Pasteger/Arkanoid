using UnityEngine;

namespace MiniIT.DESCRIPTORS
{
    [CreateAssetMenu(fileName = "Project Descriptor", menuName = "Game Descriptors/Project Descriptor")]
    public class ProjectDescriptor : ScriptableObject
    {
        [field: SerializeField] public string StartScene { get; private set; } = string.Empty;
    }
}