using System;
using UnityEngine;

public class DestroyRocket : MonoBehaviour
{
    private void Start()
    {
        DestroyingRocket();
    }

    void DestroyingRocket()
    {
        Destroy(gameObject, 3);
    }
}
