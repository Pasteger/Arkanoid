using MiniIT.ENUM;
using UnityEngine;

namespace MiniIT.INTERACTABLES.MODEL
{
    public interface IInteractableModel
    {
        public InteractableType Type { get; }
        public Vector3 Position { get; }
    }
}