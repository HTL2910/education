using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapRotation : MonoBehaviour
{
    public float swingSpeed = 2f; // Tốc độ quay
    public float swingAngle = 45f; // Góc quay tối đa
    private float initialAngle; // Góc ban đầu

    void Start()
    {
        initialAngle = transform.rotation.eulerAngles.z; // Góc ban đầu của rìu
    }

    void Update()
    {
        // Tính toán góc quay dựa trên hàm sin
        float angle = initialAngle + Mathf.Sin(Time.time * swingSpeed) * swingAngle;

        // Quay rìu
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
