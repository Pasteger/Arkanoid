using UnityEngine;

[CreateAssetMenu(fileName = "Project Descriptor", menuName = "Project Descriptors/Project Descriptor")]
public class ProjectDescriptor : ScriptableObject
{
    [field: SerializeField] public string StartScene { get; private set; } = "GameplayScene";
}
