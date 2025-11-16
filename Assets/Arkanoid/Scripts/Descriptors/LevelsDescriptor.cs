using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Levels Descriptor", menuName = "Game Descriptors/Levels Descriptor")]
public class LevelsDescriptor : ScriptableObject
{
    [field: SerializeField] private LevelData[] levels = null!;

    public LevelData GetLevel(string levelName) =>
        levelName != string.Empty
            ? levels.FirstOrDefault(description => description.LevelName == levelName)
            : levels[0];
}