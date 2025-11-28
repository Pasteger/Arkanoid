using MiniIT.DESCRIPTORS.INTERACTABLES;
using MiniIT.ENUM;
using UnityEngine;

namespace MiniIT.DESCRIPTORS
{
    [CreateAssetMenu(fileName = "Interactables Descriptor", menuName = "Game Descriptors/Interactables Descriptor")]
    public class InteractablesDescriptor : ScriptableObject
    {
        [SerializeField] private SerializableDictionary<InteractableType, BaseInteractableDescriptor> descriptors;

        public BaseInteractableDescriptor GetDescriptor(InteractableType type) => descriptors.GetValue(type);
    }
}