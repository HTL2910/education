using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Door_Properties : MonoBehaviour
{
    public bool activate;
    public bool toggleState;
    public GameObject icon;
    List<string> availableStrings=new List<string>();
    void Update()
    {
        InputNear(KeyCode.E);
    }
    protected virtual void InputNear(KeyCode keyCode)
    {
        if (activate)
        {
            icon.SetActive(true);
            if (Input.GetKeyDown(keyCode))
            {
                if (toggleState)
                {
                    toggleState = false;
                }
                else
                {
                    toggleState = true;
                }
            }
        }
        else
        {
            icon.SetActive(false);
        }
    }    

    protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            activate = true;
            if(GameManager.instance.listQuizData.Count > 0)
            {
                other.GetComponent<AN_HeroController>().enabled=false;
                other.GetComponent<AN_HeroInteractive>().enabled=false;
                availableStrings.Clear();
                UIManager ui = UIManager.instance;
                List<QuizQuestion> tmpList = GameManager.instance.listQuizData;
                ui.indexQuestion += 1;
                ui.questionPanel.SetActive(true);
                ui.questionText.text = tmpList[1].question;
                AddListString(tmpList[1]);
                RandomAnswer();
                ui.rightAnswer = tmpList[1].correctAnswer;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true; // invisible cursor
                other.GetComponent<AN_HeroController>().enabled = true;
                other.GetComponent<AN_HeroInteractive>().enabled = true;
                 // freeze cursor on screen centre
               
            }
        }
    }
    

    protected void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            activate = false;
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
        if(availableStrings.Count<=0)
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
}
