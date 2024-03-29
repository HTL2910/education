using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OndestroyOnLoad : MonoBehaviour
{
    private void Awake()
    {
        // Kiểm tra xem đối tượng đã tồn tại trong scene chưa
        GameObject existingObject = GameObject.Find(gameObject.name);
        if (existingObject != null)
        {
            // Nếu đối tượng đã tồn tại, xoá nó đi
            Destroy(existingObject);
        }

        // Thêm đối tượng mới vào scene
        GameObject newObject = Instantiate(gameObject);
        // Đảm bảo rằng đối tượng mới được giữ lại khi chuyển scene
        DontDestroyOnLoad(newObject);
    }
}
