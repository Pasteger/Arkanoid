using UniRx;
using UnityEngine;
using Zenject;

public class BrickViewModel : InteractableViewModel
{
    public readonly Subject<Unit> OnDestroy = new Subject<Unit>();

    private BrickDestruction brickDestruction;

    private BrickModel brickModel = null;

    [Inject]
    public void Construct(BrickDestruction destruction)
    {
        brickDestruction = destruction;
    }

    public override void SetModel(IInteractableModel model)
    {
        base.SetModel(model);
        brickModel = (BrickModel)model;
    }

    public override void Collide(Collision other)
    {
        if (brickDestruction.Collide(other, brickModel.IsUnbreakable))
        {
            OnDestroy.OnNext(Unit.Default);
        }
    }
}