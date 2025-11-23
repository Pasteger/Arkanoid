using UnityEngine;

public abstract class BaseUIDescriptor : ScriptableObject
{
    [field: SerializeField] public string PrefabKey { get; private set; }

    public abstract IUIViewModel ViewModel { get; }
    public abstract IUIModel Model { get; }
}