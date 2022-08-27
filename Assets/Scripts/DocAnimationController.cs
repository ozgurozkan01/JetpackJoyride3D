using System;
using UnityEngine;

public class DocAnimationController : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private DocMovement _docMovement;
    
    private void Update()
    {
        if (_docMovement.isStanding)
        {
            StandinAnimaiton();
        }

        if (_docMovement.isWalking)
        {
            WalkingAnimation();
        }
    }

    public void StandinAnimaiton()
    {
        animator.SetBool("isWalking", false);
        animator.SetBool("isRunning", false);
    }
    
    public void WalkingAnimation()
    {
        animator.SetBool("isWalking", true);
    }
    
    public void RunningAnimation()
    {           
        animator.SetBool("isRunning", true);
    }
}
