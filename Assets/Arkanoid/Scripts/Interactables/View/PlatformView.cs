using MiniIT.INTERACTABLES.MODEL;

namespace MiniIT.INTERACTABLES.VIEW
{
    public class PlatformView : BaseInteractableView
    {
        protected override void Init(IInteractableModel model)
        {
            transform.position = model.Position;
        }
    }
}