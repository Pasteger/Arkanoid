using Cysharp.Threading.Tasks;
using UnityEngine;

public class BallView : BaseInteractableView
{
    private bool isCollisionHandledThisFrame = false;

    protected override void Init(IInteractableModel model) => transform.position = model.Position;

    protected override void OnCollisionEnter(Collision other)
    {
        if (isCollisionHandledThisFrame)
        {
            return;
        }

        isCollisionHandledThisFrame = true;
        base.OnCollisionEnter(other);
        ResetCollisionFlagAsync().Forget();
    }

    private async UniTask ResetCollisionFlagAsync()
    {
        await UniTask.WaitForFixedUpdate();

        isCollisionHandledThisFrame = false;
    }
}