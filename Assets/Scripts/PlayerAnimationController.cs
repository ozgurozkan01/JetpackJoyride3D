using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerMovement playerMovement;
    
    void Update()
    {
        JetPackAnimationActivate();
    }

    private void JetPackAnimationActivate()
    {
        if (!playerMovement.isGrounded)
        {
            animator.SetBool("isJetpackActive", true);
        }
        
        else if (playerMovement.isGrounded)
        {
            animator.SetBool("isJetpackActive", false);
        }
    }
}
