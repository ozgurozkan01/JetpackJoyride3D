using System;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    [SerializeField] private Rigidbody mainRigidbody;
    private Collider mainCollider;
    private Rigidbody[] _rigidbodies;
    private Collider[] _colliders;
    [SerializeField] private Animator animator;
    
    private void Awake()
    {
        mainCollider = GetComponent<Collider>();
        _rigidbodies = GetComponentsInChildren<Rigidbody>();
        _colliders = GetComponentsInChildren<Collider>();
    }
    
    private void OwnColliderDeactive()
    {
        mainCollider.enabled = false;
    }

    private void OwnRigidBodyIsKinematic()
    {
        mainRigidbody.isKinematic = true;
    }
    
    private void DisactivateAnimator()
    {
        animator.enabled = false;
    }
    
    private void ChildsRigidBodiesIsNotKinematic()
    {
        foreach (var rb in _rigidbodies)
        {
            rb.isKinematic = false;
        }
    }
    
    private void ActivateChildrenCollider()
    {
        foreach (var col in _colliders)
        {
            col.enabled = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DisactivateAnimator();
            ChildsRigidBodiesIsNotKinematic();
            OwnRigidBodyIsKinematic();
            ActivateChildrenCollider();
            OwnColliderDeactive();
        }
    }
}
