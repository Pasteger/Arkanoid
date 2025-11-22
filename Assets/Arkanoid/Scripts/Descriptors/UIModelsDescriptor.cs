using UnityEngine;

[CreateAssetMenu(fileName = "UI Models Descriptor", menuName = "Game Descriptors/UI Models Descriptor")]
public class UIModelsDescriptor : ScriptableObject
{
    [SerializeField] private SerializableDictionary<UIType, BaseUIDescriptor> descriptors;

    public BaseUIDescriptor GetDescriptor(UIType type) => descriptors.GetValue(type);
}