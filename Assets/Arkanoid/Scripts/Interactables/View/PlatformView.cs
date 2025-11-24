public class PlatformView : BaseInteractableView
{
    protected override void Init(IInteractableModel model)
    {
        transform.position = model.Position;
    }
}