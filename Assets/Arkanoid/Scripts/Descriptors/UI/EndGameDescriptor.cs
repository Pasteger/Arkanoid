using MiniIT.UI.MODEL;
using MiniIT.UI.VIEWMODEL;
using UnityEngine;

namespace MiniIT.DESCRIPTORS.UI
{
    [CreateAssetMenu(fileName = "End Game Descriptor", menuName = "UI Descriptors/End Game Descriptor")]
    public class EndGameDescriptor : BaseUIDescriptor
    {
        [field: SerializeField] public EndGameModel EndGameModel { get; private set; }

        public override IUIViewModel ViewModel => new EndGameViewModel();
        public override IUIModel Model => new EndGameModel(EndGameModel);
    }
}