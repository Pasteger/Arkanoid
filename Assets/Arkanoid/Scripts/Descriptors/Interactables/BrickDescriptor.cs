using MiniIT.INTERACTABLES.MODEL;
using MiniIT.INTERACTABLES.VIEWMODEL;
using UnityEngine;

namespace MiniIT.DESCRIPTORS.INTERACTABLES
{
    [CreateAssetMenu(fileName = "Brick Descriptor", menuName = "Interactables Descriptors/Brick Descriptor")]
    public class BrickDescriptor : BaseInteractableDescriptor
    {
        [field: SerializeField] public BrickModel BrickModel { get; private set; }

        public override IInteractableViewModel ViewModel => new BrickViewModel();
        public override IInteractableModel Model => new BrickModel(BrickModel);
    }
}