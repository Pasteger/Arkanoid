using MiniIT.INTERACTABLES.MODEL;
using MiniIT.INTERACTABLES.VIEWMODEL;
using UnityEngine;

namespace MiniIT.DESCRIPTORS.INTERACTABLES
{
    [CreateAssetMenu(fileName = "Ball Descriptor", menuName = "Interactables Descriptors/Ball Descriptor")]
    public class BallDescriptor : BaseInteractableDescriptor
    {
        [field: SerializeField] public BallModel BallModel { get; private set; }
    
        public override IInteractableViewModel ViewModel => new BallViewModel();
        public override IInteractableModel Model => new BallModel(BallModel);
    }
}