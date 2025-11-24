using UnityEngine;

public class BrickDestruction
{
    public bool Collide(Collision other, bool isUnbreakable)
    {
        return !isUnbreakable && other.gameObject.layer == LayerMask.NameToLayer("Ball");
    }
}