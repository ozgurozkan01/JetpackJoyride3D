using UnityEngine;

public class CamereMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;

    void LateUpdate()
    {
        CameraFollowPlayer();
    }

    private void CameraFollowPlayer()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z);
    }
}
