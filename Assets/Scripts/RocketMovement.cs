using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    [SerializeField] private float rocketSpeed;
    private Vector3 _movementDirection;


    void Start()
    {
        _movementDirection = Vector3.forward;
    }
    
    void Update()
    {
        RocketMove();
    }
    
    private void RocketMove()
    {
        transform.Translate(_movementDirection * (rocketSpeed * Time.deltaTime));        
    }

}
