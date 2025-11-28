using MiniIT.INTERACTABLES.VIEWMODEL;
using MiniIT.UI.MODEL;
using MiniIT.UI.VIEWMODEL;
using UnityEngine;

namespace MiniIT.DESCRIPTORS.UI
{
    [CreateAssetMenu(fileName = "Main Menu Descriptor", menuName = "UI Descriptors/Main Menu Descriptor")]
    public class MainMenuDescriptor : BaseUIDescriptor
    {
        [field: SerializeField] public MainMenuModel MainMenuModel { get; private set; }
    
        public override IUIViewModel ViewModel => new MainMenuViewModel();
        public override IUIModel Model => new MainMenuModel(MainMenuModel);
    }
}