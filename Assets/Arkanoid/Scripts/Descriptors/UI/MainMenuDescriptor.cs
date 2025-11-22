using UnityEngine;

[CreateAssetMenu(fileName = "Main Menu Descriptor", menuName = "UI Descriptors/Main Menu Descriptor")]
public class MainMenuDescriptor : BaseUIDescriptor
{
    [field: SerializeField] public MainMenuModel Model { get; private set; }
}