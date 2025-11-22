using System;
using UniRx;

public interface IUIViewModel : IDisposable
{
    public Subject<IUIModel> OnInit { get; }

    public void SetModel(IUIModel model);
    public void InitView();
}