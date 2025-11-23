using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Main Menu Descriptor", menuName = "UI Descriptors/Main Menu Descriptor")]
public class MainMenuDescriptor : BaseUIDescriptor
{
    [field: SerializeField] public MainMenuModel MainMenuModel { get; private set; }
    
    public override IUIViewModel ViewModel => new MainMenuViewModel();
    public override IUIModel Model => new MainMenuModel(MainMenuModel);
}