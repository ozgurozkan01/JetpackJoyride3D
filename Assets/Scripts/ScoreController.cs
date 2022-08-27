using UnityEngine;
using UnityEngine.UI;
public class ScoreController : MonoBehaviour
{
    [HideInInspector] public int score;
    [SerializeField] private Text scoreText;
    [SerializeField] private CoinDestroyController coinDestroyController;
    [SerializeField] private GroundPositionController _groundPositionController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            score += 1;
            scoreText.text = score.ToString();
            coinDestroyController.DestroyCoinWhenItsTriggered(other.gameObject);
        }
    }
}
