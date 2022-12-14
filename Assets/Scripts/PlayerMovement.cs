using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float jetPackSpeed;
    [SerializeField] private float speed;
    [SerializeField] private JetpackActivation jetpackActivation;
    
    // Ground Check
    [SerializeField] private float groundDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Transform groundCheck;
    public bool isGrounded;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        MovePlayer();
        if (Input.GetMouseButton(0))
        {
            PlayerFly();
        }
        
        CheckIsGround();
    }
    
    private void MovePlayer()
    {
        _rigidbody.velocity = new Vector3(0f, _rigidbody.velocity.y, speed * Time.deltaTime);
    }

    private void PlayerFly()
    {
        jetpackActivation.JetpackActivate();
        _rigidbody.velocity = new Vector3(0f, jetPackSpeed * Time.deltaTime, _rigidbody.velocity.z);
    }

    private void CheckIsGround()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }
}
