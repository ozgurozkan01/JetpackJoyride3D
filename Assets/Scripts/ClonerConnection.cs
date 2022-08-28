using UnityEngine;

public class ClonerConnection : MonoBehaviour
{

    [SerializeField] private CoinClonerController _coinClonerController;
    [SerializeField] private SmallLaserClonerController _smallLaserController;
    [SerializeField] private LaserGroupController _laserGroupController;
    [SerializeField] private RocketClonerController _rocketClonerController;

    private int _clonerType; // 1-> coin, 2-> small laser
    private float _timeLimit = 0.75f;
    private float _timeCounter;
    private int cloneAmount;

    private float rocketSpawnerTimer;
    private float rocketSpawnerTimeLimit;
    
    private float _yPosition;
    private float _zPosition;
    private float _zPositionSum;

    public bool laserGroupActivationController = true;
    [HideInInspector] public bool _isActivatedLaserGroup;

    void Update()
    {
        ActivateControlTheLaserGroup();
        TimeControlForCreation();
        
    }

    private void UpdatePositionOfCloneObject()
    {
        _yPosition = Random.Range(5.5f, 14.5f);
        _zPosition = Random.Range(5f, 15f);

        _zPositionSum += _zPosition;
    }
    
    private void DetermineTheClonerType()
    {
        _clonerType = Random.Range(1, 12);
    }

    private void CreationAccordingToClonerType()
    {
        DetermineTheClonerType();
        UpdatePositionOfCloneObject();
        
        if (_clonerType <= 8)
        {
            _smallLaserController.CreateNewSmallLaser(_yPosition, _zPositionSum);
        }
        
        else
        {
            _coinClonerController.CreateNewCoin(_yPosition, _zPositionSum);
        }
    }

    private void TimeControlForCreation()
    {
        if (!_isActivatedLaserGroup)
        {
            _rocketClonerController.TimeControllerForFiring();
            
            if (_timeCounter >= _timeLimit)
            {
                cloneAmount += 1;
                CreationAccordingToClonerType();
                _timeCounter = 0f;
            }
            
            _timeCounter += Time.deltaTime;
        }
    }

    private void ActivateControlTheLaserGroup()
    {
        if (cloneAmount % 25 == 0 && cloneAmount != 0 && laserGroupActivationController)
        {
            _isActivatedLaserGroup = true;
            _laserGroupController.ActivateTheLasers();
            laserGroupActivationController = false;
        }
        
        else if(cloneAmount % 25 != 0)
            laserGroupActivationController = true;
    }
}
