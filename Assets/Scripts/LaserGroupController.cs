using UnityEngine;
using Random = UnityEngine.Random;

public class LaserGroupController : MonoBehaviour
{
    [SerializeField] private LaserPrefabController[] lasers;
    private int _activeLaserAmount;
    private int[] indexList = { 0, 1, 2, 3, 4, 5 };

    private void DetermineTheLaserAmount()
    {
        _activeLaserAmount = Random.Range(1, 6);
    }

    private void ShuffleTheIndexListRandomly()
    {
        for (int i = 0; i < indexList.Length; i++)
        {
            int temp;
            int rnd = Random.Range(0, indexList.Length);
            temp = indexList[rnd];
            indexList[rnd] = indexList[i];
            indexList[i] = temp;
        }
    }

    public void ActivateTheLasers()
    {
        DetermineTheLaserAmount();
        ShuffleTheIndexListRandomly();

        for (int i = 0; i < _activeLaserAmount; i++)
        {
            lasers[indexList[i]].LaserActivationCheck(true);
        }
    }

}
