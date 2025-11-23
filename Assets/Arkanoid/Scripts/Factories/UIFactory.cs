using Cysharp.Threading.Tasks;
using Zenject;

public class UIFactory
{
    private readonly PrefabKeyFactory prefabKeyFactory;
    private readonly UIModelsDescriptor uiModelsDescriptor;
    private readonly DiContainer diContainer;

    [Inject]
    public UIFactory(
        UIModelsDescriptor descriptor,
        PrefabKeyFactory prefabFactory,
        DiContainer container)
    {
        prefabKeyFactory = prefabFactory;
        uiModelsDescriptor = descriptor;
        diContainer = container;
    }

    public async UniTask<IUIView> Create(UIType uiType)
    {
        IUIView view = await CreateView(uiType);

        BaseUIDescriptor descriptor = uiModelsDescriptor.GetDescriptor(uiType);

        IUIModel model = descriptor.Model;

        IUIViewModel viewModel = descriptor.ViewModel;

        diContainer.Inject(viewModel);

        viewModel?.SetModel(model);
        view.SetViewModel(viewModel);

        return view;
    }

    private UniTask<IUIView> CreateView(UIType uiType) =>
        prefabKeyFactory.Create<IUIView>(uiModelsDescriptor.GetDescriptor(uiType).PrefabKey);
}