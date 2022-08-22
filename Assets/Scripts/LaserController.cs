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
    private bool _deactivationController;
    private int _laserAmount;
    private float _activationTimeCounter;
    private float _deactivationTimeCounter;
    [SerializeField] private float activationTime;
    [SerializeField] private float deactivationTime;

    private void Start()
    {
        player = GetComponent<GameObject>();
        player = GameObject.Find("Player");
    }
    
    private void Update()
    {
        offsetLaserLeft = player.transform.position.z - laserLeft.transform.position.z;
        offsetLaserRight = laserRight.transform.position.z - player.transform.position.z;
        LaserActivationCheck();
        LaserDeactivationCheck();
    }

    private void ReplaceTheLaserForActivation()
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

    private void ReplaceTheLaserForDeactivation()
    {
        if (offsetLaserLeft <= 10f)
        {
            laserLeft.transform.position = Vector3.Lerp(laserLeft.transform.position, laserLeft.transform.position + new Vector3(0f, 0f, -1), lerpMultiplier * Time.deltaTime);
        }
        
        if (offsetLaserRight <= 10f)
        {
            laserRight.transform.position = Vector3.Lerp(laserRight.transform.position, laserRight.transform.position + new Vector3(0f, 0f, 1f), lerpMultiplier * Time.deltaTime);
        }
    }
    
    private void CheckTimeForActivation()
    {
        if (_activationTimeCounter >= activationTime)
        {
            deactiveeLaser.gameObject.GetComponent<MeshRenderer>().enabled = false;
            activeLaser.gameObject.GetComponent<MeshRenderer>().enabled = true;
            activeLaser.gameObject.GetComponent<Collider>().enabled = true;
            LaserDeactivation();
        }

        else
        {
            _activationTimeCounter += Time.deltaTime;
        }
    }

    private void CheckTimeForDeactivation()
    {
        if (_deactivationTimeCounter >= deactivationTime)
        {
            activeLaser.gameObject.GetComponent<MeshRenderer>().enabled = false;
            activeLaser.gameObject.GetComponent<Collider>().enabled = false;
            ReplaceTheLaserForDeactivation();
        }

        else
        {
            _deactivationTimeCounter += Time.deltaTime;
        }
    }
    
    public void LaserActivation()
    {
        _activationController = true;
    }

    private void LaserDeactivation()
    {
        _activationController = false;
    }

    private void LaserActivationCheck()
    {
        if (_activationController)
        {
            ReplaceTheLaserForActivation();
            CheckTimeForActivation();
        }
    }

    private void LaserDeactivationCheck()
    {
        if (!_activationController)
        {
            CheckTimeForDeactivation();
        }
    }

}
