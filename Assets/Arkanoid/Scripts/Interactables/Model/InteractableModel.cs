using System;
using MiniIT.ENUM;
using UnityEngine;

namespace MiniIT.INTERACTABLES.MODEL
{
    [Serializable]
    public class InteractableModel : IInteractableModel
    {
        [field: SerializeField] public InteractableType Type { get; private set; }
        [field: SerializeField] public Vector3 Position { get; private set; }

        protected InteractableModel()
        {
        }

        protected InteractableModel(InteractableModel referenceModel)
        {
            Type = referenceModel.Type;
            Position = referenceModel.Position;
        }
    }
}