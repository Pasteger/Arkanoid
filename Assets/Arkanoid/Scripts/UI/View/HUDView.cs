using MiniIT.UI.MODEL;
using MiniIT.UI.VIEWMODEL;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MiniIT.UI.VIEW
{
    public class HUDView : BaseUIView, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private TMP_Text scoreLabelText;

        protected override void Init(IUIModel uiModel)
        {
            HUDModel model = (HUDModel)uiModel;
            HUDViewModel viewModel = (HUDViewModel)ViewModel;

            scoreLabelText.text = model.ScoreLabelText;
            viewModel.Score.Subscribe(score => scoreText.text = score.ToString()).AddTo(Disposables);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            HUDViewModel viewModel = (HUDViewModel)ViewModel;
            if (eventData.position.x > Screen.width / 2)
            {
                viewModel.MovePlatformRight();
            }
            else
            {
                viewModel.MovePlatformLeft();
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            HUDViewModel viewModel = (HUDViewModel)ViewModel;
            viewModel.MovePlatformReset();
        }
    }
}