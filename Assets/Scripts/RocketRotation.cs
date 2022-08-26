using UnityEngine;

public class RocketRotation : MonoBehaviour
{
    private float rotationAngle = 1;
    private float timeCounter;
    private float timeLimit = 0.5f;
    void Update()
    {
        Timer();
        RocketRotate();
    }
    
    private void RocketRotate()
    {
        transform.Rotate(rotationAngle, 0f, 0f);
    }
    
    private void Timer()
    {
        if (timeCounter >= timeLimit)
        {
            rotationAngle *= -1;
            timeCounter = 0;
        }

        timeCounter += Time.deltaTime;
    }
}
