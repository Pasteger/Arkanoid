using UnityEngine;

[CreateAssetMenu(fileName = "Audio Descriptor", menuName = "Game Descriptors/Audio Descriptor")]
public class AudioDescriptor : ScriptableObject
{
    [field: SerializeField] private SerializableDictionary<SoundName, AudioClipData> Sounds { get; set; }
    [field: SerializeField] private AudioClipData[] Musics { get; set; }

    public int MusicsLength => Musics.Length;

    public AudioClipData GetSound(SoundName soundName) => Sounds.GetValue(soundName);
    public AudioClipData GetMusic(int index) => Musics[index];
}