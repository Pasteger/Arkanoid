using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Levels Descriptor", menuName = "Game Descriptors/Levels Descriptor")]
public class LevelsDescriptor : ScriptableObject
{
    [field: SerializeField] private LevelData[] levels = null!;
    [field: SerializeField] public Vector3 PlatformPosition { get; private set; }
    [field: SerializeField] public Vector3 BallPosition { get; private set; }
    [field: SerializeField] public string BorderPrefabKey { get; private set; }

    public LevelData GetLevel(string levelName) =>
        levelName != string.Empty
            ? levels.FirstOrDefault(description => description.LevelName == levelName)
            : levels[0];
}