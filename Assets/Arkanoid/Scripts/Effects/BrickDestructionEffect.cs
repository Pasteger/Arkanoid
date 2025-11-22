using System.Collections;
using UnityEngine;

public class BrickDestructionEffect : MonoBehaviour
{
    private IEnumerator Start()
    {
        ParticleSystem particlesSystem = GetComponent<ParticleSystem>();
        particlesSystem.Play();

        yield return new WaitWhile(() => particlesSystem.isPlaying);

        Destroy(gameObject);
    }
}