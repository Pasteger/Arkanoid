using MiniIT.INTERACTABLES.MODEL;
using MiniIT.INTERACTABLES.VIEWMODEL;
using UnityEngine;

namespace MiniIT.DESCRIPTORS.INTERACTABLES
{
    public abstract class BaseInteractableDescriptor : ScriptableObject
    {
        [field: SerializeField] public string PrefabKey { get; private set; }
    
        public abstract IInteractableViewModel ViewModel{ get; }
        public abstract IInteractableModel Model{ get; }
    }
}