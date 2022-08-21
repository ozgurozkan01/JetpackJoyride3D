using System.Collections;
using UnityEngine;

public class DocClonerController : MonoBehaviour
{
    [SerializeField] private GameObject originalDocPrefab;
    [SerializeField] private float zPosition;

    private float _timeLimit = 1.5f;
    private float _timeCounter;

    void Update()
    {
        TimeController();
    }

    private void InstantiateDoc()
    {
        GameObject newDoc = Instantiate(originalDocPrefab, new Vector3(0f, 5f, zPosition), transform.rotation);
        zPositionIncreaseRandomly();
    }

    private void zPositionIncreaseRandomly()
    {
        zPosition += Random.Range(30, 45);
    }

    private void TimeController()
    {
        if (_timeCounter >= _timeLimit)
        {
            InstantiateDoc();
            _timeCounter = 0f;
        }

        _timeCounter += Time.deltaTime;
    }
    
}
