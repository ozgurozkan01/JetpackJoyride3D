using System;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    [SerializeField] private LineRenderer lr;
    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private Color[] colors;
    [SerializeField] private float lerpMultiplier;
    private RaycastHit hit;

    private void Start()
    {
        lr.startColor = colors[0];
        lr.endColor = colors[0];
    }

    void Update()
    {
        Laser();
    }

    private void Laser()
    {
        lr.SetPosition(0, transform.position);
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, 15f, targetLayer))
        {
            lr.SetPosition(1, hit.point);
        }
        ChangeLaserColorSmoothly();
    }

    private void ChangeLaserColorSmoothly()
    {
        for (int i = 0; i < colors.Length - 1; i++)
        {
            lr.startColor = Color.Lerp(colors[i], colors[i + 1], lerpMultiplier * Time.deltaTime);
            lr.endColor = Color.Lerp(colors[i], colors[i + 1], lerpMultiplier * Time.deltaTime);
        }
    }

}
