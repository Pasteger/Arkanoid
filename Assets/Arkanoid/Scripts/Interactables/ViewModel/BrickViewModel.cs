using UniRx;
using UnityEngine;
using Zenject;

public class BrickViewModel : BaseInteractableViewModel
{
    public readonly Subject<Unit> OnDestroy = new Subject<Unit>();

    private BrickDestruction brickDestruction;
    private AudioService audioService;

    private BrickModel brickModel = null;

    [Inject]
    public void Construct(BrickDestruction destruction, AudioService audios)
    {
        brickDestruction = destruction;
        audioService = audios;
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
            audioService.PlaySound(SoundName.BrickDestroy);
            OnDestroy.OnNext(Unit.Default);
        }
    }
}