using System;
using UnityEngine;

namespace MiniIT.DATA
{
    [Serializable]
    public class AudioClipData
    {
        [field: SerializeField] public AudioClip Clip { get; private set; }
        [field: SerializeField] public float Volume { get; private set; }
    }
}