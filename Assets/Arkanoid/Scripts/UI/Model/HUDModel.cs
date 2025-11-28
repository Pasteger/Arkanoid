using System;
using UniRx;
using UnityEngine;

namespace MiniIT.UI.MODEL
{
    [Serializable]
    public class HUDModel : IUIModel
    {
        [field: SerializeField] public ReactiveProperty<int> Score { get; private set; } = new ReactiveProperty<int>();
        [field: SerializeField] public string ScoreLabelText { get; private set; }

        public HUDModel(HUDModel referenceModel)
        {
            ScoreLabelText = referenceModel.ScoreLabelText;
        }
    }
}