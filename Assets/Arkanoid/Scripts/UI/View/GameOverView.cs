using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverView : BaseUIView
{
    [SerializeField] private Button restartButton;
    [SerializeField] private TMP_Text restartButtonText;
    [SerializeField] private TMP_Text messageText;
    
    protected override void Init(IUIModel uiModel)
    {
        GameOverModel model = (GameOverModel)uiModel;
        GameOverViewModel viewModel = (GameOverViewModel)ViewModel;

        restartButtonText.text = model.RestartButtonText;
        messageText.text = model.MessageText;

        restartButton.onClick.AddListener(() => viewModel.Restart());
    }

    public override void Dispose()
    {
        base.Dispose();
        restartButton.onClick.RemoveAllListeners();
    }
}