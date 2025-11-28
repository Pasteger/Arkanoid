using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using MiniIT.ENUM;
using MiniIT.FACTORIES;
using MiniIT.UI.VIEW;
using Zenject;

namespace MiniIT.LIFECYCLE
{
    public class UILoader : IInitializable, IDisposable
    {
        private readonly UIFactory                                      uiFactory = null;

        private readonly Dictionary<UIType, IUIView>                    uiViews   = null;

        [Inject]
        public UILoader(UIFactory uiFactory)
        {
            this.uiFactory = uiFactory;

            uiViews = new Dictionary<UIType, IUIView>();
        }

        public void Initialize()
        {
            LoadAllScreensAsync().Forget();
        }

        private async UniTask LoadAllScreensAsync()
        {
            foreach (UIType uiType in Enum.GetValues(typeof(UIType)))
            {
                IUIView view = await uiFactory.Create(uiType);

                uiViews.Add(uiType, view);
            }

            ShowScreen(UIType.MainMenu);
        }
        
        public void ShowScreen(UIType uiType)
        {
            foreach (KeyValuePair<UIType, IUIView> pair in uiViews)
            {
                bool isActive = pair.Key == uiType;
                pair.Value.Activate(isActive);
            }
        }

        public void Dispose()
        {
            foreach (IUIView view in uiViews.Values)
            {
                view.Dispose();
            }

            uiViews.Clear();
        }
    }
}