using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackActivation : MonoBehaviour
{
    [SerializeField] private ParticleSystem flameThrowerRight;
    [SerializeField] private ParticleSystem flameThrowerLeft;

    void Start()
    {
        flameThrowerLeft.Stop();
        flameThrowerRight.Stop();
    }
    
    public void JetpackActivate()
    {
        flameThrowerLeft.Emit(1);
        flameThrowerRight.Emit(1);
    }
    
}
