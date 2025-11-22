using System;
using UnityEngine;

[Serializable]
public class MainMenuModel : IUIModel
{
    [field: SerializeField] public string PlayButtonText { get; private set; }
    [field: SerializeField] public string ExitButtonText { get; private set; }
}