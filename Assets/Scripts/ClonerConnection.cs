using UnityEngine;

public class ClonerConnection : MonoBehaviour
{

    [SerializeField] private CoinClonerController _coinClonerController;
    [SerializeField] private SmallLaserClonerController _smallLaserController;
    [SerializeField] private LaserGroupController _laserGroupController;

    private int _clonerType; // 1-> coin, 2-> small laser
    private float _timeLimit = 1f;
    private float _timeCounter;
    private int cloneAmount;
    
    private float _yPosition;
    private float _zPosition;
    private float _zPositionSum;

    [HideInInspector] public bool _isActivatedLaserGroup;

    void Update()
    {
        ActivateControlTheLaserGroup();
        TimeControlForCreation();
        
    }

    private void UpdatePositionOfCloneObject()
    {
        _yPosition = Random.Range(7, 13);
        _zPosition = Random.Range(5, 15);

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
        if (cloneAmount % 10 == 0 && cloneAmount != 0)
        {
            _isActivatedLaserGroup = true;
            _laserGroupController.ActivateTheLasers();
        }
    }
}
