using System;
using UnityEngine;

namespace MiniIT.UI.MODEL
{
    [Serializable]
    public class MainMenuModel : IUIModel
    {
        [field: SerializeField] public string PlayButtonText { get; private set; }
        [field: SerializeField] public string ExitButtonText { get; private set; }

        public MainMenuModel(MainMenuModel referenceModel)
        {
            PlayButtonText = referenceModel.PlayButtonText;
            ExitButtonText = referenceModel.ExitButtonText;
        }
    }
}