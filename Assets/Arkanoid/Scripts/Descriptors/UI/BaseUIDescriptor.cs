using UnityEngine;

public abstract class BaseUIDescriptor : ScriptableObject
{
    [field: SerializeField] public string PrefabKey { get; private set; }
}