using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class haciaMouse : MonoBehaviour
{
    private enum Modo
    {
        Constant,
        Acceleration
    }

    [SerializeField] private Modo movementMode;
    [SerializeField] private float speed;
    private Vector3 acceleration;
    private Vector3 velocity;


    private void Update()
    {
        UpdateMovementVectors();

        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;

        RotateZ(Mathf.Atan2(velocity.y, velocity.x) - Mathf.PI / 2f);
    }

    private void UpdateMovementVectors()
    {
        if (movementMode == Modo.Constant)
        {
            velocity = GetWorldMousePosition() - transform.position;
            velocity.z = 0;
            velocity.Normalize();
            velocity *= speed;
            acceleration *= 0;
        }
        else if (movementMode == Modo.Acceleration)
        {
            acceleration = GetWorldMousePosition() - transform.position;
            velocity.z = 0;
        }
    }

    private Vector3 GetWorldMousePosition()
    {
        Camera camera = Camera.main;
        Vector3 screenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f);
        Vector4 mousePos = Camera.main.ScreenToWorldPoint(screenPosition);
        return mousePos;
    }
    private void RotateZ(float radian)
    {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, radian * Mathf.Rad2Deg);
    }
}