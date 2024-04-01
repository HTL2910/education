using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginManager: MonoBehaviour
{
    [Header("User")]
    public Button userButton;
    public GameObject userPanel;

    public Sprite userNotActive;
    public Sprite userActive;
    public GameObject tutorialPanel;

    [Header("Admin")]
    public Button adminButton;
    public GameObject adminPanel;
    public TMP_InputField name_inputField;
    public TMP_InputField password_inputField;

    public bool rightAdminlogin;

    public GameObject DialogFailedAdmin;
    public Sprite adminNotActive;
    public Sprite adminActive;
    [Header("Mode")]
    public bool userMode=true;
    public bool adminMode=false;
    public GameObject loadingPanel;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None; // freeze cursor on screen centre
        Cursor.visible = true; // invisible cursor
        if (loadingPanel.activeSelf)
        {
            loadingPanel.SetActive(false);
        }
        if (tutorialPanel.activeSelf)
        {
            tutorialPanel.SetActive(false);
        }
        
    }
    private void Update()
    {
        ChangeMode();
        if(Input.GetKeyDown(KeyCode.Return))
        {
            TutorialDeactive();
        }
    }
    private void ChangeMode()
    {
        if(userMode)
        {
            userButton.transform.GetChild(0).GetComponent<Image>().sprite = userActive;
        }
        else
        {
            userButton.transform.GetChild(0).GetComponent<Image>().sprite = userNotActive;
        }
        if (adminMode)
        {
            adminButton.transform.GetChild(0).GetComponent<Image>().sprite = adminActive;
        }
        else
        {
            adminButton.transform.GetChild(0).GetComponent<Image>().sprite = adminNotActive;
        }
        userPanel.SetActive(userMode);
        adminPanel.SetActive(adminMode);
    }   
    public void UserMode()
    {
        userMode = true;
        adminMode = false;
    }    
    public void AdminMode()
    {
        adminMode = true;
        userMode = false;
    }
    public void StartGame()
    {
        loadingPanel.SetActive(true);
        SceneManager.LoadScene("PlayGame");
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }    
    public void ConfirmLogin()
    {
        string ad = "admintakeitgame";
        string username = PlayerPrefs.GetString("username", ad);
        string pass = "passwordfromadmin";
        string password = PlayerPrefs.GetString("password", pass);
        if (name_inputField.text.ToLower() == username && password_inputField.text.ToLower() == password)
        {
            loadingPanel.SetActive(true);
            StartCoroutine(delayTime(1f));
            SceneManager.LoadScene("DataAdmin");
        }
        else
        {
            loadingPanel.SetActive(true);
            StartCoroutine(delayTime(1f));
            loadingPanel.SetActive(false);
            DialogFailedAdmin.gameObject.SetActive(true);
        }    
    }    
    private IEnumerator delayTime(float time)
    {
        yield return new WaitForSeconds(time);
    }    
    public void Again()
    {
        DialogFailedAdmin.SetActive(false);
    }    
    public void Tutorial()
    {
        tutorialPanel.SetActive(true);
    }    
    public void TutorialDeactive()
    {
        tutorialPanel.SetActive(false);
    }    
}
