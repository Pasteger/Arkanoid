using UniRx;
using UnityEngine;

public class BrickViewModel : InteractableViewModel
{
    public readonly Subject<Unit> OnDestroy = new Subject<Unit>();

    private readonly BrickDestruction brickDestruction;

    private BrickModel brickModel = null;

    public BrickViewModel(BrickDestruction brickDestruction)
    {
        this.brickDestruction = brickDestruction;
        this.brickDestruction.OnDestroy.Subscribe(OnDestroy.OnNext).AddTo(Disposables);
    }

    public override void SetModel(IInteractableModel model)
    {
        base.SetModel(model);
        brickModel = (BrickModel)model;
    }

    public override void Collide(Collision other) => brickDestruction.Collide(other, brickModel.IsUnbreakable);
}