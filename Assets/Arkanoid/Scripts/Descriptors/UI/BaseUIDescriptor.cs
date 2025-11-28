using MiniIT.UI.MODEL;
using MiniIT.UI.VIEWMODEL;
using UnityEngine;

namespace MiniIT.DESCRIPTORS.UI
{
    public abstract class BaseUIDescriptor : ScriptableObject
    {
        [field: SerializeField] public string PrefabKey { get; private set; }

        public abstract IUIViewModel ViewModel { get; }
        public abstract IUIModel Model { get; }
    }
}