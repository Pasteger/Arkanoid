using UniRx;
using UnityEngine;

public class BrickDestruction
{
    public readonly Subject<Unit> OnBrickDestroyed = new Subject<Unit>();

    public bool Collide(Collision other, bool isUnbreakable)
    {
        if (isUnbreakable || other.gameObject.layer != LayerMask.NameToLayer("Ball")) return false;

        OnBrickDestroyed.OnNext(Unit.Default);
        return true;
    }
}