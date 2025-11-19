using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

public class InteractablesFactory
{
    private readonly InteractablesPrefabKeysDescriptor    interactablesPrefabKeysDescriptor;
    private readonly PrefabKeyFactory                     prefabKeyFactory;

    [Inject]
    public InteractablesFactory(InteractablesPrefabKeysDescriptor prefabKeysDescriptor, PrefabKeyFactory prefabFactory)
    {
        interactablesPrefabKeysDescriptor = prefabKeysDescriptor;
        prefabKeyFactory = prefabFactory;
    }

    public UniTask<IInteractableView> Create(InteractableType interactableType) => 
        prefabKeyFactory.Create<IInteractableView>(interactablesPrefabKeysDescriptor.GetKey(interactableType));
}