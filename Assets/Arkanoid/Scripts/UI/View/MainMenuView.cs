using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : BaseUIView
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private TMP_Text playButtonText;
    [SerializeField] private TMP_Text exitButtonText;

    protected override void Init(IUIModel uiModel)
    {
        MainMenuModel model = (MainMenuModel)uiModel;
        MainMenuViewModel viewModel = (MainMenuViewModel)ViewModel;

        playButtonText.text = model.PlayButtonText;
        exitButtonText.text = model.ExitButtonText;

        playButton.onClick.AddListener(() => viewModel.PlayGame());
        exitButton.onClick.AddListener(() => viewModel.ExitGame());
    }
}