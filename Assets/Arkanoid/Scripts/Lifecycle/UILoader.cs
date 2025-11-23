using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Zenject;

public class UILoader : IInitializable, IDisposable
{
    private readonly UIFactory uiFactory;

    private readonly Dictionary<UIType, IUIView> views = new Dictionary<UIType, IUIView>();

    public UILoader(UIFactory factory) => uiFactory = factory;

    public void Initialize() => Load().Forget();

    private async UniTask Load()
    {
        int count = Enum.GetNames(typeof(UIType)).Length;
        for (int i = 0; i < count; i++)
        {
            IUIView uiView = await uiFactory.Create((UIType)i);

            views.Add((UIType)i, uiView);
        }
        
        views[UIType.MainMenu].Activate(true);
    }

    public void Dispose()
    {
        foreach (IUIView view in views.Values)
        {
            view.Dispose();
        }
    }
}