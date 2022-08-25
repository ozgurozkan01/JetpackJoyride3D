using UnityEngine;

public class RocketPointFollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject playerVerticalPoint;
    [SerializeField] private float lerpMultiplier;
    [SerializeField] private RocketClonerController rocketClonerController;
    private Vector3 _rocketOffset;

    
    void Start()
    {
                
        playerVerticalPoint = GetComponent<GameObject>();
        playerVerticalPoint = GameObject.Find("Player");
        
        _rocketOffset = transform.position - playerVerticalPoint.transform.position;
    }
    
    void Update()
    {
        RocketPointFollowTargetBeforeFiring();
    }
    
    private void RocketPointFollowTargetBeforeFiring()
    {
        if (!rocketClonerController.firingController)
        {
            transform.position= Vector3.Lerp(transform.position, playerVerticalPoint.transform.position + _rocketOffset,
                lerpMultiplier * Time.deltaTime);   
        }
    }
}
