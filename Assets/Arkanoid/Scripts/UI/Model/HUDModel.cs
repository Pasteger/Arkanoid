using System;
using UniRx;
using UnityEngine;

[Serializable]
public class HUDModel : IUIModel
{
    [field: SerializeField] public ReactiveProperty<int> Score { get; private set; } = new ReactiveProperty<int>();
    [field: SerializeField] public string ScoreLabelText { get; private set; }
}