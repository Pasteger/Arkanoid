using Cysharp.Threading.Tasks;
using MiniIT.LIFECYCLE;
using Zenject;

namespace MiniIT.UI.VIEWMODEL
{
    public class MainMenuViewModel : BaseUIViewModel
    {
        private LevelLoader levelLoader;
        private GameExit gameExit;

        [Inject]
        public void Construct(LevelLoader loader, GameExit exit)
        {
            levelLoader = loader;
            gameExit = exit;
        }

        public void PlayGame()
        {
            levelLoader.LoadLevelAsync().Forget();
            OnActivate.OnNext(false);
        }

        public void ExitGame() => gameExit.Exit();

        protected override void Subscribe()
        {
        }
    }
}