using UnityEngine;

public class CoinDestroyController : MonoBehaviour
{
    public void DestroyCoinWhenItsTriggered(GameObject coin)
    {
        Destroy(coin.gameObject);
    }
}
