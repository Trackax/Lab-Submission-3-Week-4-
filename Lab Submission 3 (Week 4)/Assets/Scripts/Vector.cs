using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Vector : MonoBehaviour
{
    public Transform player;
    public Transform thisObject;
    public float orbitDistance = 5f;
    public float orbitSpeed = 30f;
    public float currentAngle = 0f;

    void Update()
    {
        currentAngle += orbitSpeed * Time.deltaTime;
        currentAngle %= 360f;
        float angleRadius = currentAngle * Mathf.Deg2Rad;
        float orbitX = player.position.x + orbitDistance * Mathf.Cos(currentAngle);
        float orbitY = player.position.y + orbitDistance * Mathf.Sin(currentAngle);
        float orbitZ = player.position.z;
        transform.position = new Vector3(orbitX, orbitY, orbitZ);
        
        Vector3 direction = player.position - thisObject.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = targetRotation;
    }
}
