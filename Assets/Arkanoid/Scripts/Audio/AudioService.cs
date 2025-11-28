using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using MiniIT.DATA;
using MiniIT.DESCRIPTORS;
using MiniIT.ENUM;
using UnityEngine;
using Zenject;

namespace MiniIT.AUDIO
{
    public class AudioService : IInitializable, IDisposable
    {
        private readonly AudioSource     audioSource;
        private readonly AudioDescriptor audioDescriptor;

        private CancellationTokenSource cancellationTokenSource = null; // всегда = null по умолчанию

        [Inject]
        public AudioService(AudioSource audioSource, AudioDescriptor audioDescriptor)
        {
            this.audioSource     = audioSource;
            this.audioDescriptor = audioDescriptor;
        }

        public void Initialize()
        {
            cancellationTokenSource = new CancellationTokenSource();

            PlayMusicLoopAsync(cancellationTokenSource.Token).Forget();
        }

        public void PlaySound(SoundName soundName)
        {
            AudioClipData soundData = audioDescriptor.GetSound(soundName);

            audioSource.PlayOneShot(soundData.Clip, soundData.Volume);
        }

        private async UniTask PlayMusicLoopAsync(CancellationToken cancellationToken)
        {
            int index = 0;

            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    if (index >= audioDescriptor.MusicsLength)
                    {
                        index = 0;
                    }

                    AudioClipData musicData = audioDescriptor.GetMusic(index);

                    audioSource.clip   = musicData.Clip;
                    audioSource.volume = musicData.Volume;
                    audioSource.Play();

                    index++;

                    await UniTask.WaitWhile(() => audioSource.isPlaying, cancellationToken: cancellationToken);
                }
            }
            catch (OperationCanceledException)
            {
            }
        }

        public void Dispose()
        {
            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
                cancellationTokenSource.Dispose();
                cancellationTokenSource = null;
            }
        }
    }
}