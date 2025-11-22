using UniRx;

public class HUDViewModel : BaseUIViewModel
{
    public readonly ReactiveProperty<int> Score = new ReactiveProperty<int>();

    protected override void Subscribe()
    {
        HUDModel hudModel = (HUDModel)Model;

        hudModel.Score.Subscribe(score => Score.Value = score).AddTo(Disposables);
    }
}