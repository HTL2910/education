using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [Header("Time")]
    [SerializeField] TextMeshProUGUI timeText;
    private float startTime;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        float elapsedTime = Time.time - startTime;

        // Tính số phút và giây.
        int minutes = (int)(elapsedTime / 60);
        int seconds = (int)(elapsedTime % 60);

        // Hiển thị thời gian dưới dạng "00:00".
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
