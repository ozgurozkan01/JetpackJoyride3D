using UnityEngine;
using UnityEngine.UI;
public class ScoreController : MonoBehaviour
{
    [HideInInspector] public int score;
    [SerializeField] private Text scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            score += 1;
            scoreText.text = score.ToString();
        }
    }
}
