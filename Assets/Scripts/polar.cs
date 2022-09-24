using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class polar : MonoBehaviour
{

    [Header("Polar")]
    [SerializeField] private float radioinicial = 1f;
    [SerializeField] [Range(0, 10)] private float speed = 1f;
    private float angle;
    private float radius = 0.5f;
    [SerializeField] Camera camera;

    void Update()
    {
        

        if (Mathf.Abs(radius) > camera.orthographicSize)
        {
            speed *= -1;
            radioinicial *= -1;
        }
       
        angle += speed * Time.deltaTime;
        radius += radioinicial * Time.deltaTime;

        Vector3 cartesian = PolarToCartesian(radius, angle);
        transform.localPosition = cartesian;

        Debug.DrawLine(Vector3.zero, cartesian, Color.red);
    }
    Vector3 PolarToCartesian(float radio, float angulo)
    {
        return new Vector3(radio * Mathf.Cos(angulo), radio * Mathf.Sin(angulo));
    }
}
