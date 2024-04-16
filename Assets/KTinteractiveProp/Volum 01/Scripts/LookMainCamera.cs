using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KTintercativeProp
{
    public class LookMainCamera : MonoBehaviour
    {

        void Update()
        {
            // Lấy vị trí của camera
            Vector3 cameraPosition = Camera.main.transform.position;

            // Tạo vector hướng từ đối tượng đến camera
            Vector3 lookDirection = cameraPosition - transform.position;

            // Chuyển đổi vector hướng thành hướng quay
            Quaternion targetRotation = Quaternion.LookRotation(lookDirection, Vector3.up);

            // Gán hướng quay cho đối tượng
            transform.rotation = targetRotation;
            Quaternion currentRotation = transform.rotation;

            // Tạo một quaternion mới đại diện cho quay 180 độ quanh trục y
            Quaternion rotationToAdd = Quaternion.Euler(0f, 180f, 0f);

            // Kết hợp quay mới với quay hiện tại của đối tượng
            Quaternion newRotation = currentRotation * rotationToAdd;

            // Gán hướng quay mới cho đối tượng
            transform.rotation = newRotation;
        }


    }
}