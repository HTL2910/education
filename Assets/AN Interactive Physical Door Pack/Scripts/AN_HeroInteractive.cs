using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AN_HeroInteractive : MonoBehaviour
{
    [Tooltip("Are you have any key?")]
    public bool RedKey = false, BlueKey = false;
    [Tooltip("Child empty object for plug following")]
    public Transform GoalPosition;

    List<string> availableStrings = new List<string>();
    List<QuizQuestion> tmpList=new List<QuizQuestion>();
    bool lightIsActive = true;
    private void Start()
    {
        tmpList = GameManager.instance.listQuizData;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            lightIsActive = !lightIsActive;
            
            gameObject.GetComponentInChildren<Light>().enabled = lightIsActive;
            
        }    
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Door"))
        {
            if (tmpList.Count > 0 && RedKey == false && UIManager.instance.questionPanel.activeSelf == false && other.GetComponent<Door_Properties>().acitvePanel == false)
            {
               
                gameObject.GetComponent<AN_HeroController>().enabled = false;
                gameObject.GetComponent<AN_HeroInteractive>().enabled = false;
                availableStrings.Clear();
                UIManager ui = UIManager.instance;
                ui.indexQuestion += 1;
                ui.questionPanel.SetActive(true);
                int indexQuizdata=Random.Range(0, tmpList.Count);

                ui.questionText.text = tmpList[indexQuizdata].question;
                AddListString(tmpList[indexQuizdata]);
                RandomAnswer();
                ui.rightAnswer = tmpList[indexQuizdata].correctAnswer;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true; // invisible cursor
                gameObject.GetComponent<AN_HeroController>().enabled = true;
                gameObject.GetComponent<AN_HeroInteractive>().enabled = true;
                // freeze cursor on screen centre
                tmpList.RemoveAt(indexQuizdata);
                other.GetComponent<Door_Properties>().acitvePanel = true;
            }
        }   
        if(other.CompareTag("Book"))
        {
            Debug.Log("Book");
        }    
    }
   
    private void RandomAnswer()
    {
        UIManager.instance.AButton.GetComponentInChildren<TMP_Text>().text = GetUniqueRandomString();
        UIManager.instance.BButton.GetComponentInChildren<TMP_Text>().text = GetUniqueRandomString();
        UIManager.instance.CButton.GetComponentInChildren<TMP_Text>().text = GetUniqueRandomString();
        UIManager.instance.DButton.GetComponentInChildren<TMP_Text>().text = GetUniqueRandomString();


    }
    private void AddListString(QuizQuestion question)
    {
        if (availableStrings.Count <= 0)
        {
            availableStrings.Add(question.optionA);
            availableStrings.Add(question.optionB);
            availableStrings.Add(question.optionC);
            availableStrings.Add(question.optionD);
        }
    }
    private string GetUniqueRandomString()
    {
        if (availableStrings.Count == 0)
        {
            Debug.LogWarning("No available strings left!");
            return "";
        }

        int randomIndex = Random.Range(0, availableStrings.Count);
        string randomString = availableStrings[randomIndex];
        availableStrings.RemoveAt(randomIndex);
        return randomString;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Trap"))
        {
            UIManager.instance.dieDialog.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        
    }
    
    
}
