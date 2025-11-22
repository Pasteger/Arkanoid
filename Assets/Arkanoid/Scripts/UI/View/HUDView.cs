using TMPro;
using UniRx;
using UnityEngine;

public class HUDView : BaseUIView
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
}