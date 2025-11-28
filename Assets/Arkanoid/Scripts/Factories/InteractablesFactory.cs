using Cysharp.Threading.Tasks;
using MiniIT.DESCRIPTORS;
using MiniIT.DESCRIPTORS.INTERACTABLES;
using MiniIT.ENUM;
using MiniIT.INTERACTABLES.MODEL;
using MiniIT.INTERACTABLES.VIEW;
using MiniIT.INTERACTABLES.VIEWMODEL;
using Zenject;

namespace MiniIT.FACTORIES
{
    public class InteractablesFactory
    {
        private readonly PrefabKeyFactory        prefabKeyFactory        = null;
        private readonly InteractablesDescriptor interactablesDescriptor = null;
        private readonly DiContainer             diContainer             = null;

        [Inject]
        public InteractablesFactory(
            InteractablesDescriptor interactablesDescriptor,
            PrefabKeyFactory prefabKeyFactory,
            DiContainer diContainer)
        {
            this.interactablesDescriptor = interactablesDescriptor;
            this.prefabKeyFactory         = prefabKeyFactory;
            this.diContainer              = diContainer;
        }
        
        public async UniTask<IInteractableView> Create(InteractableType interactableType)
        {
            IInteractableView view = await CreateViewAsync(interactableType);

            BaseInteractableDescriptor descriptor = interactablesDescriptor.GetDescriptor(interactableType);

            IInteractableViewModel viewModel = descriptor.ViewModel;
            IInteractableModel model         = descriptor.Model;

            diContainer.Inject(viewModel);

            viewModel.SetModel(model);
            view.SetViewModel(viewModel);

            return view;
        }
        
        private async UniTask<IInteractableView> CreateViewAsync(InteractableType interactableType)
        {
            BaseInteractableDescriptor descriptor = interactablesDescriptor.GetDescriptor(interactableType);

            return await prefabKeyFactory.Create<IInteractableView>(descriptor.PrefabKey);
        }
    }
}