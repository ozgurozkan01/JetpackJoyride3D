using UnityEngine;
using Random = UnityEngine.Random;

public class SmallLaserClonerController : MonoBehaviour
{
    [SerializeField] private GameObject dynamicLaserPrefab;
    private int _laserType; // 1-> dynamix (can rotate), 2-> static (no move)

    private void DetermineTheLaserType()
    {
        _laserType = Random.Range(1, 3);
    }

    public void CreateNewSmallLaser(float yPosition, float zPosition)
    {
        DetermineTheLaserType();

        if (_laserType == 1)
        {
            GameObject newDynamicLaser = Instantiate(dynamicLaserPrefab, new Vector3(0f, yPosition, zPosition), transform.rotation);
            newDynamicLaser.gameObject.AddComponent<RotateDynamicLaser>();
        }
        
        else if (_laserType == 2)
        {
            GameObject newDynamicLaser = Instantiate(dynamicLaserPrefab, new Vector3(0f, yPosition, zPosition), transform.rotation);
        }
    }
}
