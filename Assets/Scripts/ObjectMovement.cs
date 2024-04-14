using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float speed = 5f; // Tốc độ di chuyển
    public float xDirection = 1f; // Hướng theo trục x
    public float yDirection = 0f; // Hướng theo trục y
    public float zDirection = 0f; // Hướng theo trục z

    void Update()
    {
        // Vector chỉ hướng di chuyển
        Vector3 direction = new Vector3(xDirection, yDirection, zDirection);

        // Di chuyển đối tượng
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
