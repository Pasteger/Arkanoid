using Cysharp.Threading.Tasks;
using Zenject;

public class InteractablesFactory
{
    private readonly PrefabKeyFactory prefabKeyFactory;
    private readonly InteractablesDescriptor interactableDescriptor;
    private readonly DiContainer diContainer;

    [Inject]
    public InteractablesFactory(
        InteractablesDescriptor descriptor,
        PrefabKeyFactory prefabFactory,
        DiContainer container)
    {
        prefabKeyFactory = prefabFactory;
        interactableDescriptor = descriptor;
        diContainer = container;
    }

    public async UniTask<IInteractableView> Create(InteractableType interactableType)
    {
        IInteractableView view = await CreateView(interactableType);

        BaseInteractableDescriptor descriptor = interactableDescriptor.GetDescriptor(interactableType);

        IInteractableViewModel viewModel = descriptor.ViewModel;
        IInteractableModel model = descriptor.Model;

        diContainer.Inject(viewModel);
        viewModel.SetModel(model);
        view.SetViewModel(viewModel);

        return view;
    }

    private UniTask<IInteractableView> CreateView(InteractableType interactableType) =>
        prefabKeyFactory.Create<IInteractableView>(interactableDescriptor.GetDescriptor(interactableType).PrefabKey);
}