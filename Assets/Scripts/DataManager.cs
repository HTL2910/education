using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    [Header("List Data")]
    [SerializeField] public List<QuizQuestion> quizQuestions = new List<QuizQuestion>();
    [SerializeField] public List<QuizQuestion> ListquizQuestions = new List<QuizQuestion>();
    [Header("path file save")]
    public string dataSavePath;

    [Header("UI")]
    public GameObject panelLoading;
    private void Awake()
    {
        instance = this;
    }
    private IEnumerator Delay(float  delay)
    {
        yield return delay;
        
    }    
    public void DelayInLoading()
    {
        if (panelLoading != null)
        {
            panelLoading.SetActive(true);
            StartCoroutine(Delay(1f));
            panelLoading.SetActive(false);
        }
        else
        {
            StartCoroutine(Delay(1f));
        }

    }
}
