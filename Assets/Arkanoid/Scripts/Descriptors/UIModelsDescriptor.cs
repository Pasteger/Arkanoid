using MiniIT.DESCRIPTORS.UI;
using MiniIT.ENUM;
using UnityEngine;

namespace MiniIT.DESCRIPTORS
{
    [CreateAssetMenu(fileName = "UI Models Descriptor", menuName = "Game Descriptors/UI Models Descriptor")]
    public class UIModelsDescriptor : ScriptableObject
    {
        [SerializeField] private SerializableDictionary<UIType, BaseUIDescriptor> descriptors;

        public BaseUIDescriptor GetDescriptor(UIType type) => descriptors.GetValue(type);
    }
}