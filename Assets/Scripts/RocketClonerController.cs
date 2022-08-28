using System;
using UnityEngine;

public class RocketClonerController : MonoBehaviour
{
    [SerializeField] private GameObject originalRocketPrefab;
    [SerializeField] private Transform rocketPoint;
    [HideInInspector] public bool firingController;
    
    public float _timeLimit;
    private float _timeCounter;

    private void CreateNewRocket()
    {
        GameObject newRocket = Instantiate(originalRocketPrefab, rocketPoint.transform.position, Quaternion.identity);
        newRocket.transform.rotation = Quaternion.Euler(-180, 0f, 0f);
    }

    public void TimeControllerForFiring()
    {
        if (_timeCounter >= _timeLimit)
        {
            firingController = true;
            CreateNewRocket();
            firingController = false;
            _timeCounter = 0;
        }
    
        _timeCounter += Time.deltaTime;
    }
}   
