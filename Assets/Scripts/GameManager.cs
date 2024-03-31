﻿using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager :MonoBehaviour
{
    public static GameManager instance;
    [Header("Data")]
    [SerializeField] public List<QuizQuestion> listQuizData = new List<QuizQuestion>();
    private void Awake()
    {
        instance = this;
        if (File.Exists(PlayerPrefs.GetString("dataPath")))
        {

            string jsonData = File.ReadAllText(PlayerPrefs.GetString("dataPath"));
            listQuizData = JsonConvert.DeserializeObject<List<QuizQuestion>>(jsonData);
        }
        else
        {
            Debug.Log("Not dataPath");
        }
    }
  
}
