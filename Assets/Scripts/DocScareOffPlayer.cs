using UnityEngine;

public class DocScareOffPlayer : MonoBehaviour
{
    private float offsetMagnitude;
    private Vector3 offset;
    private float runAwayDistanceLimit = 7f;
    [SerializeField] private GameObject player;
    [SerializeField] private DocAnimationController docAnimCont;
    [SerializeField] private DocMovement docMovement;

    void Start()
    {
        player = GetComponent<GameObject>();
        player = GameObject.Find("Player");
    }
    
    void Update()
    {
        UpdateOffset();
        DocRunAway();
    }

    private void UpdateOffset()
    {
        offset = transform.position - player.transform.position;
        offsetMagnitude = offset.magnitude;
    }

    public void UpdateDocRunAwayDirection()
    {
        if (docMovement._directionType == 0)
        {
            docMovement.gameObject.transform.Rotate(0f, -180f, 0f);
            docMovement._directionType = 1;
        }
    }
    
    public void DocRunAway()
    {
        if (offsetMagnitude <= runAwayDistanceLimit)
        {
            UpdateDocRunAwayDirection();
            docMovement.isWalking = false;
            docMovement.isStanding = false;
            docMovement._currentSpeed = docMovement.runSpeed;
            docAnimCont.RunningAnimation();   
        }
    }
}
