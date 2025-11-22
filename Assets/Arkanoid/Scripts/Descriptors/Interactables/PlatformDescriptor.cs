using UnityEngine;

[CreateAssetMenu(fileName = "Platform Descriptor", menuName = "Interactables Descriptors/Platform Descriptor")]
public class PlatformDescriptor : BaseInteractableDescriptor
{
    [field: SerializeField] public PlatformModel PlatformModel { get; private set; }

    public override IInteractableViewModel ViewModel => new PlatformViewModel(new PlatformMovement(PlatformModel.MoveSpeed.Value));
    public override IInteractableModel Model => new PlatformModel(PlatformModel);
}