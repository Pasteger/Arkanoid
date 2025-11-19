using System;
using UnityEngine;

[Serializable]
public class BrickModel : InteractableModel
{
    [field: SerializeField] public bool IsUnbreakable { get; private set; }
    [field: SerializeField] public Color Color { get; private set; }
}