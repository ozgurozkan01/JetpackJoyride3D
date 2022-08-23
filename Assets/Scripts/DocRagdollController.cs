using UnityEngine;

public class DocRagdollController : MonoBehaviour
{
    [SerializeField] private Rigidbody mainRigidbody;
    [SerializeField] private Collider mainCollider;
    [SerializeField] private float explosionMultiplier;
    private Rigidbody[] _rigidbodies;
    private Collider[] _colliders;
    [SerializeField] private Animator animator;

    void Start()
    {
        GetRagdollComponents();
        RagdollModeOff();
    }

    void GetRagdollComponents()
    {
        _rigidbodies = GetComponentsInChildren<Rigidbody>();
        _colliders = GetComponentsInChildren<Collider>();
    }

    void RagdollModeOn()
    {
        animator.enabled = false;
        
        foreach (var rb in _rigidbodies)
        {
            rb.isKinematic = false;
        }

        foreach (var col in _colliders)
        {
            col.enabled = true;
        }
        
        mainCollider.enabled = false;
        mainRigidbody.isKinematic = false;
    }

    void RagdollModeOff()
    {

        
        foreach (var rb in _rigidbodies)
        {
            rb.isKinematic = true;
        }

        foreach (var col in _colliders)
        {
            col.enabled = false;
        }
        
        animator.enabled = true;
        mainCollider.enabled = true;
        mainRigidbody.isKinematic = false;
    }

    private void RollDownDocWhenPlayerHits()
    {
        foreach (var rb in _rigidbodies)
        {
            rb.AddExplosionForce(1000f * explosionMultiplier, transform.position + new Vector3(0f, 0f, -5f), 50f);
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            RagdollModeOn();
            RollDownDocWhenPlayerHits();
        }
    }
}
