using System;
using UnityEngine;

[Serializable]
public class InteractableModel : IInteractableModel
{
    [field: SerializeField] public InteractableType Type { get; private set; }
    [field: SerializeField] public Vector3 Position { get; private set; }
}