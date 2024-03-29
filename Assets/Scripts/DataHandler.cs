using UnityEngine;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

public class DataHandler : MonoBehaviour
{
    void Start()
    {
        // Đường dẫn để lưu trữ dữ liệu JSON trong thư mục PersistentDataPath của ứng dụng
        DataManager.instance.dataSavePath = Application.persistentDataPath + "/quiz_data.json";
        Debug.Log( DataManager.instance.dataSavePath);
       
    }

    public void SaveData(List<QuizQuestion> data)
    {
        // Chuyển đổi danh sách câu hỏi thành chuỗi JSON
        string jsonData = JsonConvert.SerializeObject(data);
        // Lưu chuỗi JSON vào tệp
        File.WriteAllText( DataManager.instance.dataSavePath, jsonData);
    }

    public List<QuizQuestion> LoadData()
    {
        List<QuizQuestion> data = new List<QuizQuestion>();
        // Kiểm tra xem tệp tồn tại
        if (File.Exists( DataManager.instance.dataSavePath))
        {
            // Đọc dữ liệu từ tệp và chuyển đổi thành danh sách câu hỏi
            string jsonData = File.ReadAllText( DataManager.instance.dataSavePath);
            data = JsonConvert.DeserializeObject<List<QuizQuestion>>(jsonData);
        }
        return data;
    }
}
