using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float jetPackSpeed;
    [SerializeField] private float speed;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MovePlayer();
        if (Input.GetMouseButton(0))
        {
            JetPackActivate();
        }
    }
    
    private void MovePlayer()
    {
        _rigidbody.velocity = new Vector3(0f, _rigidbody.velocity.y, speed * Time.deltaTime);
    }

    private void JetPackActivate()
    {
        _rigidbody.velocity = new Vector3(0f, jetPackSpeed * Time.deltaTime, _rigidbody.velocity.z);
    }
}
