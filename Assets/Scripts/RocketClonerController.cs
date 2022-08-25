using System;
using UnityEngine;

public class RocketClonerController : MonoBehaviour
{
    [SerializeField] private GameObject originalRocketPrefab;
    [SerializeField] private Transform rocketPoint;
    [HideInInspector] public bool firingController;


    private float _timeLimit = 3f;
    private float _timeCounter;

    private void Update()
    {
        TimeControllerForFiring();
    }

    private void CreateNewRocket()
    {
        GameObject newRocket = Instantiate(originalRocketPrefab, rocketPoint.transform.position, Quaternion.identity);
        newRocket.transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
    }

    private void TimeControllerForFiring()
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
