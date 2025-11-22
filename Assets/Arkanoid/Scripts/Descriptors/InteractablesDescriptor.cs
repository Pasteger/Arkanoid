using UnityEngine;

[CreateAssetMenu(fileName = "Interactables Descriptor", menuName = "Game Descriptors/Interactables Descriptor")]
public class InteractablesDescriptor : ScriptableObject
{
    [SerializeField] private SerializableDictionary<InteractableType, BaseInteractableDescriptor> descriptors;

    public BaseInteractableDescriptor GetDescriptor(InteractableType type) => descriptors.GetValue(type);
}