using System;
using MiniIT.UI.MODEL;
using UniRx;

namespace MiniIT.UI.VIEWMODEL
{
    public interface IUIViewModel : IDisposable
    {
        public Subject<IUIModel> OnInit { get; }
        public Subject<bool> OnActivate { get; }

        public void SetModel(IUIModel model);
        public void InitView();
    }
}