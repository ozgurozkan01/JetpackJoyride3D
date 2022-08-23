﻿using UnityEngine;

public class DocMovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float fallDownForce;
    [SerializeField] private DocAnimationController docAnimCont;
    private float _currentSpeed;
    private Rigidbody _rigidbody;
    private Vector3 direction;
    private int _directionType;
    
    void Start()
    {
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

    public void DetermineDocMoveSpeed()
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
