using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class EndGameView : BaseUIView
{
    [SerializeField] private Button nextButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private TMP_Text nextButtonText;
    [SerializeField] private TMP_Text exitButtonText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text scoreLabelText;
    
    protected override void Init(IUIModel uiModel)
    {
        EndGameModel model = (EndGameModel)uiModel;
        EndGameViewModel viewModel = (EndGameViewModel)ViewModel;

        nextButtonText.text = model.NextButtonText;
        exitButtonText.text = model.ExitButtonText;
        scoreLabelText.text = model.ScoreLabelText;

        nextButton.onClick.AddListener(() => viewModel.NextLevel());
        exitButton.onClick.AddListener(() => viewModel.ExitGame());
        
        viewModel.Score.Subscribe(score => scoreText.text = score.ToString()).AddTo(Disposables);
    }

    public override void Dispose()
    {
        base.Dispose();
        nextButton.onClick.RemoveAllListeners();
        exitButton.onClick.RemoveAllListeners();
    }
}