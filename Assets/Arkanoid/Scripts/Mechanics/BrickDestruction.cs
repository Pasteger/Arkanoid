using UniRx;
using UnityEngine;

namespace MiniIT.MECHANICS
{
    public class BrickDestruction
    {
        public Subject<Unit> OnBrickDestroyed { get; } = new Subject<Unit>();
        
        public bool Collide(Collision collision, bool isUnbreakable)
        {
            if (collision == null || 
                collision.gameObject.layer != LayerMask.NameToLayer("Ball"))
            {
                return false;
            }

            if (isUnbreakable)
            {
                return false;
            }

            OnBrickDestroyed.OnNext(Unit.Default);

            return true;
        }
    }
}