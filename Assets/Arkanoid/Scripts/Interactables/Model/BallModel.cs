using System;
using UniRx;
using UnityEngine;

[Serializable]
public class BallModel : InteractableModel
{
    [field: SerializeField] public ReactiveProperty<float> MoveSpeed { get; private set; } = new ReactiveProperty<float>();

    protected BallModel(float moveSpeed)
    {
        MoveSpeed.Value = moveSpeed;
    }
}