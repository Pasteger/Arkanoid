using UniRx;
using UnityEngine;

public class BrickDestruction
{
    public readonly Subject<Unit> OnDestroy = new Subject<Unit>();

    public void Collide(Collision other, bool isUnbreakable)
    {
        if (!isUnbreakable && other.gameObject.layer == LayerMask.NameToLayer("Ball"))
        {
            OnDestroy.OnNext(Unit.Default);
        }
    }
}