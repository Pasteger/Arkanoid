using Cysharp.Threading.Tasks;
using MiniIT.DESCRIPTORS;
using MiniIT.DESCRIPTORS.UI;
using MiniIT.ENUM;
using MiniIT.UI.MODEL;
using MiniIT.UI.VIEW;
using MiniIT.UI.VIEWMODEL;
using Zenject;

namespace MiniIT.FACTORIES
{
    public class UIFactory
    {
        private readonly PrefabKeyFactory   prefabKeyFactory     = null;
        private readonly UIModelsDescriptor uiModelsDescriptor   = null;
        private readonly DiContainer        diContainer          = null;

        [Inject]
        public UIFactory(
            UIModelsDescriptor uiModelsDescriptor,
            PrefabKeyFactory prefabKeyFactory,
            DiContainer diContainer)
        {
            this.uiModelsDescriptor = uiModelsDescriptor;
            this.prefabKeyFactory    = prefabKeyFactory;
            this.diContainer         = diContainer;
        }
        
        public async UniTask<IUIView> Create(UIType uiType)
        {
            IUIView view = await CreateViewAsync(uiType);

            BaseUIDescriptor descriptor = uiModelsDescriptor.GetDescriptor(uiType);

            IUIModel model = descriptor.Model;
            IUIViewModel viewModel = descriptor.ViewModel;

            diContainer.Inject(viewModel);

            viewModel.SetModel(model);
            view.SetViewModel(viewModel);

            return view;
        }
        
        private async UniTask<IUIView> CreateViewAsync(UIType uiType)
        {
            BaseUIDescriptor descriptor = uiModelsDescriptor.GetDescriptor(uiType);

            return await prefabKeyFactory.Create<IUIView>(descriptor.PrefabKey);
        }
    }
}