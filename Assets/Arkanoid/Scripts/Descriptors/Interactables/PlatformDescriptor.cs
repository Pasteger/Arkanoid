using MiniIT.INTERACTABLES.MODEL;
using MiniIT.INTERACTABLES.VIEWMODEL;
using UnityEngine;

namespace MiniIT.DESCRIPTORS.INTERACTABLES
{
    [CreateAssetMenu(fileName = "Platform Descriptor", menuName = "Interactables Descriptors/Platform Descriptor")]
    public class PlatformDescriptor : BaseInteractableDescriptor
    {
        [field: SerializeField] public PlatformModel PlatformModel { get; private set; }

        public override IInteractableViewModel ViewModel => new PlatformViewModel();
        public override IInteractableModel Model => new PlatformModel(PlatformModel);
    }
}