using UnityEngine;

[CreateAssetMenu(fileName = "Game Over Descriptor", menuName = "UI Descriptors/Game Over Descriptor")]

public class GameOverDescriptor: BaseUIDescriptor
{
    [field: SerializeField] public GameOverModel GameOverModel { get; private set; }

    public override IUIViewModel ViewModel => new GameOverViewModel();
    public override IUIModel Model => new GameOverModel(GameOverModel);
}