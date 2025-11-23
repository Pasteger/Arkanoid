using System;
using UnityEngine;

[CreateAssetMenu(fileName = "HUD Descriptor", menuName = "UI Descriptors/HUD Descriptor")]
public class HUDDescriptor : BaseUIDescriptor
{
    [field: SerializeField] public HUDModel HUDModel { get; private set; }

    public override IUIViewModel ViewModel => new HUDViewModel();
    public override IUIModel Model => new HUDModel(HUDModel);
}