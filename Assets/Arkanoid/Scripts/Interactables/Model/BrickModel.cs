using System;
using UnityEngine;

[Serializable]
public class BrickModel : InteractableModel
{
    [field: SerializeField] public bool IsUnbreakable { get; private set; }
    [field: SerializeField] public Color Color { get; private set; }
    [field: SerializeField] public Color UnbreakableColor { get; private set; } = Color.gray;

    public BrickModel()
    {
    }

    public BrickModel(BrickModel referenceModel) : base(referenceModel)
    {
        IsUnbreakable = referenceModel.IsUnbreakable;
        Color = referenceModel.Color;
    }
}