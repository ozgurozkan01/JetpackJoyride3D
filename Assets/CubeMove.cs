using UnityEngine;

public class CubeMove : MonoBehaviour
{
    void Update()
    {
        transform.Translate(1 * Time.deltaTime, 0f, 0f);       
    }
}
