using UnityEngine;

[CreateAssetMenu(fileName = "Interactables Prefab Keys Descriptor",
    menuName = "Interactables Descriptors/Interactables Prefab Keys Descriptor")]
public class InteractablesPrefabKeysDescriptor : ScriptableObject
{
    [field: SerializeField] private SerializableDictionary<InteractableType, string> prefabKeysForType = null!;
    
    public string GetKey(InteractableType type) => prefabKeysForType.GetValue(type);
}