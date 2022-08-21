using UnityEngine;
using Random = UnityEngine.Random;

public class DocAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [HideInInspector] public int typeOfAnimation; // 1-> Walk, 2-> Run

    private void Start()
    {
        ActivateTheAnimation();
    }

    private void DetermineAnimatonTypeOfDocRandomly()
    {
        typeOfAnimation = Random.Range(1, 3);
    }

    private void ActivateTheAnimation()
    {
        DetermineAnimatonTypeOfDocRandomly();
        if (typeOfAnimation == 1)
        {
            animator.SetBool("isWalking", true);
        }
        
        else if (typeOfAnimation == 2)
        {
            animator.SetBool("isRunning", true);
        }
    }
}
