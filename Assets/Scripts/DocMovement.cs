using UnityEngine;

public class DocMovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed;
    public float runSpeed;
    [SerializeField] private DocAnimationController docAnimCont;
    [HideInInspector] public float _currentSpeed;
    private Rigidbody _rigidbody;
    private Vector3 direction;
    [HideInInspector] public int _directionType;
    private int _movementType;

    [HideInInspector] public bool isWalking;
    [HideInInspector] public bool isStanding;
    void Start()
    {
        DetermineMovementType();
        DetermineDirectionType();
        DetermineDocMoveSpeed();
        AttachTheDirectionDoc();
        direction = Vector3.forward;
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    void LateUpdate()
    {
        MoveDoc();
    }

    private void DetermineMovementType()
    {
        _movementType = Random.Range(1, 3);
    }
    
    public void DetermineDocMoveSpeed()
    {
        //Idle
        if (_movementType == 1)
        {
            isStanding = true;
            _currentSpeed = 0;
        }
        
        //Walk
        else if (_movementType == 2)
        {
            isWalking = true;
            _currentSpeed = walkSpeed;
        }
    }

    private void MoveDoc()
    {
        if (_directionType == 0)
        {
            _rigidbody.velocity = new Vector3(0f, _rigidbody.velocity.y, -_currentSpeed * Time.deltaTime);
        }
        
        else if (_directionType == 1)
        {
            _rigidbody.velocity = new Vector3(0f, _rigidbody.velocity.y, _currentSpeed * Time.deltaTime);
        }
    }
    
    
    public void DetermineDirectionType()
    {
        _directionType = Random.Range(0, 2); // 0-> -Z, 1-> +Z
    }

    public void AttachTheDirectionDoc()
    {
        if (_directionType == 0)
        {
            gameObject.transform.Rotate(0f, 180f, 0f);
        }
    }
}
