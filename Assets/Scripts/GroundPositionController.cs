using System;
using UnityEngine;

public class GroundPositionController : MonoBehaviour
{
    [SerializeField] private Transform ground;
    private float addDistance = 100f;
    
    public void UpdateGroundPosition()
    {
        ground.position = new Vector3(ground.position.x, ground.position.y, ground.position.z + addDistance);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UpdateGroundPosition();
        }
    }
}
