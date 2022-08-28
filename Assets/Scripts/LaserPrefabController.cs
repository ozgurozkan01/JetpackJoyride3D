using UnityEngine;

public class LaserPrefabController : MonoBehaviour
{
    private float offsetLaserLeft;
    private float offsetLaserRight;
    [SerializeField] private GameObject laserLeft;
    [SerializeField] private GameObject laserRight;
    [SerializeField] private GameObject deactiveeLaser;
    [SerializeField] private GameObject activeLaser;
    [SerializeField] private float lerpMultiplier;
    [SerializeField] private GameObject player;
    [SerializeField] private ClonerConnection _clonerConnection;
    
    private bool _activationTimer;
    private bool _deactivationTimer;
    private int _laserAmount;
    private float _activationTimeCounter;
    private float _deactivationTimeCounter;
    [SerializeField] private float activationTime;
    [SerializeField] private float deactivationTime;

    private void Start()
    {
        _clonerConnection = GetComponent<ClonerConnection>();
        _clonerConnection = FindObjectOfType<ClonerConnection>();
        player = GetComponent<GameObject>();
        player = GameObject.Find("Player");
    }
    
    private void Update()
    {
        offsetLaserLeft = player.transform.position.z - laserLeft.transform.position.z;
        offsetLaserRight = laserRight.transform.position.z - player.transform.position.z;

        if (_activationTimer)
        {
            ReplaceTheLaserForActivation();
            CheckTimeForActivation();
        }
        
        else if (!_activationTimer)
        {
            _activationTimeCounter = 0;
            LaserActivationCheck(false);
        }
        
        if (_deactivationTimer)
        {
            CheckTimeForDeactivation();
        }
        
        else if (!_deactivationTimer) 
        {
            _deactivationTimeCounter = 0;
        }
    }

    private void ReplaceTheLaserForActivation()
    {
        if (offsetLaserLeft >= 10f)
        {
            laserLeft.transform.position = Vector3.Lerp(laserLeft.transform.position, laserLeft.transform.position + new Vector3(0f, 0f, 1), lerpMultiplier * Time.deltaTime);
        }
        
        if (offsetLaserRight >= 10f)
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
        if (offsetLaserLeft <= 12.5f)
        {
            laserLeft.transform.position = Vector3.Lerp(laserLeft.transform.position, laserLeft.transform.position + new Vector3(0f, 0f, -1), lerpMultiplier * Time.deltaTime);
        }
        
        if (offsetLaserRight <= 12.5f)
        {
            laserRight.transform.position = Vector3.Lerp(laserRight.transform.position, laserRight.transform.position + new Vector3(0f, 0f, 1f), lerpMultiplier * Time.deltaTime);
        }

        else
        {
            _clonerConnection._isActivatedLaserGroup = false;
        }
    }
    
    private void CheckTimeForActivation()
    {
        if (_activationTimeCounter >= activationTime)
        {
                deactiveeLaser.gameObject.GetComponent<MeshRenderer>().enabled = false;
                activeLaser.gameObject.GetComponent<MeshRenderer>().enabled = true;
                activeLaser.gameObject.GetComponent<Collider>().enabled = true;
                _activationTimer = false;
        }
            
        _activationTimeCounter += Time.deltaTime;

    }

    private void CheckTimeForDeactivation()
    {
        if (_deactivationTimeCounter >= deactivationTime)
        {
            activeLaser.gameObject.GetComponent<MeshRenderer>().enabled = false;
            activeLaser.gameObject.GetComponent<Collider>().enabled = false;
            ReplaceTheLaserForDeactivation();
            _deactivationTimer = false;
        }

        _deactivationTimeCounter += Time.deltaTime;
    }
    
    public void LaserActivationCheck(bool isActivated)
    {
        if (!isActivated)
        {
            _deactivationTimer = true;
        }
        
        else if (isActivated)
        {
            _activationTimer = true;
        }
    }
    
}
