using System.Collections.Generic;
using MiniIT.AUDIO;
using MiniIT.ENUM;
using MiniIT.LIFECYCLE;
using UniRx;
using Zenject;

namespace MiniIT.UI.VIEWMODEL
{
    public class GameOverViewModel : BaseUIViewModel
    {
        private LevelLoader levelLoader;
        private GameFinalizer gameFinalizer;
        private AudioService audioService;

        [Inject]
        public void Construct(LevelLoader loader, GameFinalizer finalizer, AudioService audios)
        {
            levelLoader = loader;
            gameFinalizer = finalizer;
            audioService = audios;
        }

        public void Restart()
        {
            levelLoader.ReloadLevel();
            OnActivate.OnNext(false);
        }

        protected override void Subscribe()
        {
            gameFinalizer.OnFinish.Subscribe(Activate).AddTo(Disposables);
        }

        private void Activate(KeyValuePair<EndGameType, int> result)
        {
            if (result.Key != EndGameType.Over)
            {
                return;
            }

            OnActivate.OnNext(true);
            audioService.PlaySound(SoundName.GameOver);
        }
    }
}