using UnityEngine;

public class DocMovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private DocAnimationController docAnimCont;
    private float _currentSpeed;
    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        MoveDoc();
    }

    private void DetermineDocMoveSpeed()
    {
        if (docAnimCont.typeOfAnimation == 1)
        {
            _currentSpeed = walkSpeed;
        }
        
        else if (docAnimCont.typeOfAnimation == 2)
        {
            _currentSpeed = runSpeed;
        }
    }

    private void MoveDoc()
    {
        DetermineDocMoveSpeed();
        _rigidbody.AddForce(_currentSpeed * Time.deltaTime * Vector3.forward, ForceMode.Acceleration);
    }
    
}
