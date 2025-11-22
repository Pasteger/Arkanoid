using Cysharp.Threading.Tasks;
using Zenject;

public class InteractablesFactory
{
    private readonly PrefabKeyFactory prefabKeyFactory;
    private readonly InteractablesDescriptor interactableDescriptor;

    [Inject]
    public InteractablesFactory(InteractablesDescriptor descriptor,
        PrefabKeyFactory prefabFactory)
    {
        prefabKeyFactory = prefabFactory;
        interactableDescriptor = descriptor;
    }

    public async UniTask<IInteractableView> Create(InteractableType interactableType)
    {
        IInteractableView view = await CreateView(interactableType);

        BaseInteractableDescriptor descriptor = interactableDescriptor.GetDescriptor(interactableType);

        IInteractableViewModel viewModel = descriptor.ViewModel;
        IInteractableModel model = descriptor.Model;

        view.SetViewModel(viewModel);
        viewModel.SetModel(model);

        return view;
    }

    private UniTask<IInteractableView> CreateView(InteractableType interactableType) =>
        prefabKeyFactory.Create<IInteractableView>(interactableDescriptor.GetDescriptor(interactableType).PrefabKey);
}