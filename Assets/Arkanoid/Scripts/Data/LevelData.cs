using System;
using MiniIT.INTERACTABLES.MODEL;
using UnityEngine;

namespace MiniIT.DATA
{
    [Serializable]
    public class LevelData
    {
        [field: SerializeField] public string LevelName { get; private set; } = string.Empty;
        [field: SerializeField] public string NextLevelName { get; private set; } = string.Empty;
        [field: SerializeField] public BrickModel[] Bricks { get; private set; } = Array.Empty<BrickModel>();
    }
}