using UnityEngine;

public class CoinClonerController : MonoBehaviour
{
    [SerializeField] private GameObject[] coinPrefabs;

    private int _yPosition;
    private int _zPosition;
    [SerializeField] private int _zPositionSum;
    private int _coinType;

    private void Start()
    {
        CreateNewCoin();
        Debug.Log(_yPosition);
    }

    private void DeterminePositionOfCoin()
    {
        _yPosition = Random.Range(8, 13);
        _zPosition = Random.Range(20, 40);

        _zPositionSum += _zPosition;
    }

    private void DetermineCoinTypeRandomly()
    {
        _coinType = Random.Range(0, 5);
    }
    
    private void CreateNewCoin()
    {
        DeterminePositionOfCoin();
        DetermineCoinTypeRandomly();
        GameObject newCoin = Instantiate(coinPrefabs[_coinType], new Vector3(0f, _yPosition, _zPositionSum) , Quaternion.identity);
    }
}
