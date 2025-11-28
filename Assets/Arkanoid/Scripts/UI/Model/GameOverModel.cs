using System;
using UnityEngine;

namespace MiniIT.UI.MODEL
{
    [Serializable]
    public class GameOverModel : IUIModel
    {
        [field: SerializeField] public string MessageText { get; private set; }
        [field: SerializeField] public string RestartButtonText { get; private set; }
    
        public GameOverModel(GameOverModel referenceModel)
        {
            MessageText = referenceModel.MessageText;
            RestartButtonText = referenceModel.RestartButtonText;
        }
    }
}