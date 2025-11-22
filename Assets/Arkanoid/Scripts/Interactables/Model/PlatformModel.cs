using System;
using UniRx;
using UnityEngine;

[Serializable]
public class PlatformModel : InteractableModel
{
    [field: SerializeField]
    public ReactiveProperty<float> MoveSpeed { get; private set; } = new ReactiveProperty<float>();

    public PlatformModel()
    {
    }

    public PlatformModel(PlatformModel referenceModel) : base(referenceModel) =>
        MoveSpeed.Value = referenceModel.MoveSpeed.Value;
}