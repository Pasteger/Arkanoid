using System;
using UniRx;
using UnityEngine;

[Serializable]
public class BallModel : InteractableModel
{
    [field: SerializeField]
    public ReactiveProperty<float> MoveSpeed { get; private set; } = new ReactiveProperty<float>();

    [field: SerializeField]
    public ReactiveProperty<Vector3> Direction { get; private set; } = new ReactiveProperty<Vector3>();

    public BallModel()
    {
    }

    public BallModel(BallModel referenceModel) : base(referenceModel)
    {
        MoveSpeed.Value = referenceModel.MoveSpeed.Value;
        Direction.Value = referenceModel.Direction.Value;
    }
}