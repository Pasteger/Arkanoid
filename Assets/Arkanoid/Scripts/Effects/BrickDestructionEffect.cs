using Cysharp.Threading.Tasks;
using UnityEngine;

namespace MiniIT.EFFECTS
{
    public class BrickDestructionEffect : MonoBehaviour
    {
        private void Start()
        {
            PlayAndDestroyAsync().Forget();
        }
        
        private async UniTaskVoid PlayAndDestroyAsync()
        {
            ParticleSystem particlesSystem = GetComponent<ParticleSystem>();
            particlesSystem.Play();

            await UniTask.WaitWhile(() => particlesSystem.isPlaying);

            Destroy(gameObject);
        }
    }
}