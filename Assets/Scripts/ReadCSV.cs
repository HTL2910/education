using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using TMPro;
using System.IO;

public class ReadCSV : MonoBehaviour
{
    public TMP_InputField urlInputField; // InputField để nhập đường dẫn Google Drive
    private string downloadUrl;
    
    
    private DataHandler dataHandler;

    public void StartReadingCSV()
    {
        string fileId = GetFileIdFromUrl(urlInputField.text);

        if (fileId == null)
        {
            Debug.LogError("Invalid Google Drive URL");
            return;
        }

        // Tạo URL để tải xuống từ Google Drive
        downloadUrl = "https://drive.google.com/uc?id=" + fileId;

        StartCoroutine(DownloadCSV());
    }

    private IEnumerator DownloadCSV()
    {
        UnityWebRequest www = UnityWebRequest.Get(downloadUrl);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error downloading CSV: " + www.error);
            yield break;
        }

        string[] lines = www.downloadHandler.text.Split(new char[] { '\n' });

        // Kiểm tra xem dữ liệu có ít nhất hai dòng (bao gồm dòng tiêu đề) không
        if (lines.Length < 2)
        {
            Debug.LogError("CSV file is empty or missing header row.");
            yield break;
        }

        // Lặp qua mỗi dòng trong file CSV, bắt đầu từ dòng thứ 2 (chỉ số 1) vì dòng đầu tiên là tiêu đề
        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i].Trim(); // Loại bỏ khoảng trắng thừa từ đầu và cuối dòng

            if (string.IsNullOrEmpty(line))
                continue; // Bỏ qua dòng trống

            string[] values = line.Split(new char[] { ',' });

            // Kiểm tra xem có đủ giá trị trong dòng không
            if (values.Length < 6)
            {
                Debug.LogWarning("Skipping invalid CSV line: " + line);
                continue;
            }

            // Tạo một đối tượng QuizQuestion từ dữ liệu trong dòng CSV
            QuizQuestion question = new QuizQuestion();
            question.question = values[0];
            question.optionA = values[1];
            question.optionB = values[2];
            question.optionC = values[3];
            question.optionD = values[4];
            question.correctAnswer = values[5];

            // Thêm đối tượng QuizQuestion vào danh sách
            DataManager.instance.quizQuestions.Add(question);
        }
     
        // In ra thông tin của các câu hỏi đã được tải từ file CSV
        foreach (var question in DataManager.instance.quizQuestions)
        {
            Debug.Log("Question: " + question.question);
            Debug.Log("Option A: " + question.optionA);
            Debug.Log("Option B: " + question.optionB);
            Debug.Log("Option C: " + question.optionC);
            Debug.Log("Option D: " + question.optionD);
            Debug.Log("Correct Answer: " + question.correctAnswer);
            Debug.Log("-------------------------");
        }
    }

    // Phương thức để lấy fileId từ URL Google Drive
    private string GetFileIdFromUrl(string url)
    {
        // Tìm chuỗi "/d/" trong URL
        int startIndex = url.IndexOf("/d/");
        if (startIndex == -1)
            return null;

        startIndex += 3; // Bắt đầu từ vị trí sau "/d/"
        int endIndex = url.IndexOf("/", startIndex);

        if (endIndex == -1)
        {
            // Nếu không tìm thấy "/", sử dụng độ dài của chuỗi làm endIndex
            endIndex = url.Length;
        }

        // Lấy fileId từ URL
        return url.Substring(startIndex, endIndex - startIndex);
    }
    

    void Start()
    {
        dataHandler = GetComponent<DataHandler>();
    }
    public void Save()
    {
        SaveQuizData(DataManager.instance.quizQuestions);
        DataManager.instance.DelayInLoading();
    }    
     
    public void SaveQuizData(List<QuizQuestion> quizData)
    {
        Debug.Log("Save");
        dataHandler.SaveData(quizData);
    }
   
    public void Load()
    {
        DataManager.instance.ListquizQuestions = LoadQuizData();
        //foreach (var question in DataManager.instance.ListquizQuestions)
        //{
        //    Debug.Log("Question: " + question.question);
        //    Debug.Log("Option A: " + question.optionA);
        //    Debug.Log("Option B: " + question.optionB);
        //    Debug.Log("Option C: " + question.optionC);
        //    Debug.Log("Option D: " + question.optionD);
        //    Debug.Log("Correct Answer: " + question.correctAnswer);
        //    Debug.Log("-------------------------");
        //}
        DataManager.instance.DelayInLoading();
    }

    public List<QuizQuestion> LoadQuizData()
    {
        Debug.Log("Load");
        return dataHandler.LoadData();
    }

}
