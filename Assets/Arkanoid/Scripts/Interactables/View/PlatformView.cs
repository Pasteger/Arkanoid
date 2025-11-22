public class PlatformView : InteractableView
{
    protected override void Init(IInteractableModel model)
    {
        transform.position = model.Position;
    }
}