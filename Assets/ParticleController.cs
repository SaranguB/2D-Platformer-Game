using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public ParticleSystem particle;

    public void PlayPlayerWinEffect()
    {
        particle.Play();
    }
}
