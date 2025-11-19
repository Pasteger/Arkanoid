using UnityEngine;

public interface IInteractableModel
{
    public InteractableType Type { get; }
    public Vector3 Position { get; }
}