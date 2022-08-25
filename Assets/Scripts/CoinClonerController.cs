using UnityEngine;

public class CoinClonerController : MonoBehaviour
{
    [SerializeField] private GameObject[] coinPrefabs;
    
    private int _coinType;

    private void DetermineCoinTypeRandomly()
    {
        _coinType = Random.Range(0, 5);
    }
    
    public void CreateNewCoin(float yPosition, float zPosition)
    {
        DetermineCoinTypeRandomly();
        GameObject newCoin = Instantiate(coinPrefabs[_coinType], new Vector3(0f, yPosition, zPosition) , Quaternion.identity);
    }
    
    
}
