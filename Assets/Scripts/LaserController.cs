using UnityEngine;

public class LaserController : MonoBehaviour
{
    private float offsetLaserLeft;
    private float offsetLaserRight;
    [SerializeField] private GameObject laserLeft;
    [SerializeField] private GameObject laserRight;
    [SerializeField] private GameObject deactiveeLaser;
    [SerializeField] private GameObject activeLaser;
    [SerializeField] private float lerpMultiplier;
    [SerializeField] private GameObject player;

    private bool _activationController;
    private int _laserAmount;
    private float _timeCounter;
    [SerializeField] private float activationTime;

    private void Start()
    {
        player = GetComponent<GameObject>();
        player = GameObject.Find("Player");
    }
    
    private void Update()
    {
        LaserActivationCheck();
    }

    private void ActivateLaser()
    {
        deactiveeLaser.gameObject.GetComponent<MeshRenderer>().enabled = false;
        activeLaser.gameObject.GetComponent<MeshRenderer>().enabled = true;
        activeLaser.gameObject.GetComponent<Collider>().enabled = true;
    }

    private void ReplaceTheLaser()
    {
        if (offsetLaserLeft >= 7.5f)
        {
            laserLeft.transform.position = Vector3.Lerp(laserLeft.transform.position, laserLeft.transform.position + new Vector3(0f, 0f, 1), lerpMultiplier * Time.deltaTime);
        }
        
        if (offsetLaserRight >= 7.5f)
        {
            laserRight.transform.position = Vector3.Lerp(laserRight.transform.position, laserRight.transform.position + new Vector3(0f, 0f, -1f), lerpMultiplier * Time.deltaTime);
        }

        else
        {
            deactiveeLaser.gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
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
        
    public void LaserActivation()
    {
        _activationController = true;
    }


    private void LaserActivationCheck()
    {
        if (_activationController)
        {
            offsetLaserLeft = player.transform.position.z - laserLeft.transform.position.z;
            offsetLaserRight = laserRight.transform.position.z - player.transform.position.z;
            ReplaceTheLaser();
            CheckTimeForActivation();
        }
    }

}
