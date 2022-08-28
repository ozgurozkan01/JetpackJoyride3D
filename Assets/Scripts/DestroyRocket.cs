using System;
using UnityEngine;

public class DestroyRocket : MonoBehaviour
{
    [SerializeField] private ExplosionParticleController expParticleCont;
    
    private void Start()
    {
        expParticleCont = GetComponent<ExplosionParticleController>();
        expParticleCont = FindObjectOfType<ExplosionParticleController>();
        
        DestroyingRocket();
    }

    void DestroyingRocket()
    {
        Destroy(gameObject, 5);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            expParticleCont.ExplosionParticleEffectActivate();
            Destroy(gameObject);
        }
    }
}
