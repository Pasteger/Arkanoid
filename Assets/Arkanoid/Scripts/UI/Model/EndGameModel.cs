using System;
using UniRx;
using UnityEngine;

namespace MiniIT.UI.MODEL
{
    [Serializable]
    public class EndGameModel : IUIModel
    {
        [field: SerializeField] public ReactiveProperty<int> Score { get; private set; } = new ReactiveProperty<int>();
        [field: SerializeField] public string ScoreLabelText { get; private set; }
        [field: SerializeField] public string NextButtonText { get; private set; }
        [field: SerializeField] public string ExitButtonText { get; private set; }
    
        public EndGameModel(EndGameModel referenceModel)
        {
            ScoreLabelText = referenceModel.ScoreLabelText;
            NextButtonText = referenceModel.NextButtonText;
            ExitButtonText = referenceModel.ExitButtonText;
        }
    }
}