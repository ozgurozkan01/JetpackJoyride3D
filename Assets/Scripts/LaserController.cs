using UnityEngine;

public class LaserController : MonoBehaviour
{
    [SerializeField] private GameObject deactiveeLaser;
    [SerializeField] private GameObject activeLaser;

    private int _laserAmount;
    private float _timeCounter;
    [SerializeField] private float activationTime;
    private void Update()
    {
        CheckTimeForActivation();
    }

    private void ActivateLaser()
    {
        deactiveeLaser.gameObject.GetComponent<MeshRenderer>().enabled = false;
        activeLaser.gameObject.GetComponent<MeshRenderer>().enabled = true;
        activeLaser.gameObject.GetComponent<Collider>().enabled = true;
    }

    private void CheckTimeForActivation()
    {
        if (_timeCounter >= activationTime)
        {
            ActivateLaser();
            _timeCounter = activationTime;
        }

        else
        {
            _timeCounter += Time.deltaTime;
        }
    }

}
