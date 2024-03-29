using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    [Header("List Data")]
    [SerializeField] public List<QuizQuestion> quizQuestions = new List<QuizQuestion>();
    [SerializeField] public List<QuizQuestion> ListquizQuestions = new List<QuizQuestion>();
    [Header("path file save")]
    public string dataSavePath;
    private void Awake()
    {
        instance = this;
    }
    public IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(delay);
    }    
   
}
