using UnityEngine;
using Random = UnityEngine.Random;

public class SmallLaserClonerController : MonoBehaviour
{
    [SerializeField] private GameObject dynamicLaserPrefab;
    private int _laserType; // 1-> dynamix (can rotate), 2-> static (no move)
    private float[] rotationAngles = {0, 45, 90, 135};
    private int angleIndex;
    
    private void DetermineTheLaserType()
    {
        _laserType = Random.Range(1, 3);
    }

    public void CreateNewSmallLaser(float yPosition, float zPosition)
    {
        DetermineTheLaserType();

        if (_laserType == 1)
        {
            GameObject newSmallLaser = Instantiate(dynamicLaserPrefab, new Vector3(0f, yPosition, zPosition), transform.rotation);
            newSmallLaser.gameObject.AddComponent<RotateSmallLaser>();
        }
        
        else if (_laserType == 2)
        {
            GameObject newSmallLaser = Instantiate(dynamicLaserPrefab, new Vector3(0f, yPosition, zPosition), transform.rotation);
            angleIndex = Random.Range(0, 4);
            newSmallLaser.transform.rotation = Quaternion.Euler(rotationAngles[angleIndex], 0f, 0f);
        }
    }
}
