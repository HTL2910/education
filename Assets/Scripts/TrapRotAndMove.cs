using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapRotAndMove : MonoBehaviour
{
    public float rotationSpeed = 100f; // Tốc độ quay của bẫy
    public float moveSpeed = 5f; // Tốc độ di chuyển của bẫy
    public Vector3 moveDirection = Vector3.forward; // Hướng di chuyển của bẫy

    void Update()
    {
        // Quay bẫy xung quanh trục 
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        // Di chuyển bẫy theo hướng và tốc độ đã chỉ định
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
