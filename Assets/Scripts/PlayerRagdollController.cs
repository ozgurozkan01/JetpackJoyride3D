using UnityEngine;

public class PlayerRagdollController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody _mainRb;
    [SerializeField] private Collider _mainColl;
    private Rigidbody[] _rigidbodies;
    private Collider[] _colliders;

    private void Start()
    {
        _rigidbodies = GetComponentsInChildren<Rigidbody>();
        _colliders = GetComponentsInChildren<Collider>();
    }

    private void DeactivateAnimator()
    {
        _animator.enabled = false;
    }

    private void MainRigidBodyIsKinematic()
    {
        _mainRb.isKinematic = true;
    }

    private void MainColliderIsDeactivate()
    {
        _mainColl.enabled = false;
    }
    
    private void ChildrenRigidBodiesIsNotKınematic()
    {
        foreach (var _rb in _rigidbodies)
        {
            _rb.isKinematic = false;
        }
    }

    private void ActivateChildrenColliders()
    {
        foreach (var col in _colliders)
        {
            col.enabled = true;
        }
    }

    private void RagdollActivation()
    {
        DeactivateAnimator();
        ChildrenRigidBodiesIsNotKınematic();
        ActivateChildrenColliders();
        MainColliderIsDeactivate();
        MainRigidBodyIsKinematic();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            Debug.Log("1");
            RagdollActivation();
        }
        
        else if (collision.gameObject.CompareTag("Rocket"))
        {
            RagdollActivation();
        }
    }
}
