using UnityEngine;

public class GroundPositionController : MonoBehaviour
{
    [SerializeField] private ScoreController _scoreController;
    private float addDistance = 50f;
    
    public void UpdateGroundPosition()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + addDistance);
    }
}
