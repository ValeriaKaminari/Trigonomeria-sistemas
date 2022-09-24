using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMousePosition : MonoBehaviour
{
    private float velocidad;
    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = GetWorldMousePosition();
        var position = transform.position;
        Vector3 thisPos = position;
        Vector3 direction = (mousePos - thisPos).normalized;
        var lookAt = direction * velocidad;
        Target(thisPos + lookAt);
        Vector3 endPos = new Vector3(lookAt.x, lookAt.y, 0);
        position += endPos * Time.deltaTime;
        transform.position = position;
    }

    private Vector4 GetWorldMousePosition()
    {
        Camera camera = Camera.main;
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane);
        Vector4 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        worldPos.z = 0;
        return worldPos;
    }

    private void RotateZ(float radians)
    {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, radians * Mathf.Rad2Deg);
    }

    private void Target(Vector3 t)
    {
        Vector3 mousePosition = GetWorldMousePosition();
        Vector3 dif = mousePosition - transform.position;
        float radians = Mathf.Atan2(dif.y, dif.x);
        RotateZ(radians - Mathf.PI / 2);
    }
}