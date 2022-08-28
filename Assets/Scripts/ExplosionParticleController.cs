using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionParticleController : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosionParticle;
    void Start()
    {
        explosionParticle.Stop();
    }

    public void ExplosionParticleEffectActivate()
    {
        explosionParticle.Emit(1);
    }
}
