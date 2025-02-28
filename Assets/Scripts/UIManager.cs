﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [Header("Time")]
    [SerializeField] TextMeshProUGUI timeText;
    private float startTime;
    [Header("Question")]
    public TextMeshProUGUI questionText;
    public Button AButton;
    public Button BButton;
    public Button CButton;
    public Button DButton;
    public string yourAnswer=string.Empty;
    public string rightAnswer=string.Empty;

    public int indexQuestion = 0;
    public GameObject questionPanel;

    public TextMeshProUGUI rightAnswerText;
    public TextMeshProUGUI countWrongAnswerText;
    public int countRightAnswer = 0;
    public int countWrongAnswer = 0;
    int countQuestion = 0; 

    private AN_HeroInteractive player;
    [Header("Dialog")]
    public GameObject dialogPanel;
    public TextMeshProUGUI dialogText;
    [Header("Die")]
    public GameObject dieDialog;
    [Header("Knowdelge")]
    public GameObject knowdelgePanel;
    public TextMeshProUGUI knowdelgeText;
    public Image knowdelgeImage;
    public List<string> listText=new List<string>();
    public List<Sprite> listSprite=new List<Sprite>();
    private void Awake()
    {
        instance = this;
        TextAsset[] textAssets = Resources.LoadAll<TextAsset>("Text");
        Sprite[] spriteAsset = Resources.LoadAll<Sprite>("Image");
     
        foreach (TextAsset textAsset in textAssets)
        {
            listText.Add(textAsset.text);
        }
        foreach(Sprite sprite in spriteAsset)
        {
            listSprite.Add(sprite);
        }    


    }
    void Start()
    {
        player=FindObjectOfType<AN_HeroInteractive>();
        startTime = Time.time;
        AddOnClick();
        Deactive(dialogPanel);
        Deactive(dieDialog);
        Deactive(questionPanel);
        Deactive(knowdelgePanel);

        countQuestion = GameManager.instance.listQuizData.Count;
    }
    public void Deactive(GameObject Obj)
    {
        if(Obj.activeSelf)
        {
            Obj.SetActive(false);
        }    
    }    
    public void KnowPanelDeactive()
    {
        Deactive(knowdelgePanel);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }    
    public void AddOnClick()
    {
        AButton.onClick.AddListener(() => MyAnswer(AButton));
        BButton.onClick.AddListener(() => MyAnswer(BButton));
        CButton.onClick.AddListener(() => MyAnswer(CButton));
        DButton.onClick.AddListener(() => MyAnswer(DButton));
    }    
    public void Update()
    {
        float elapsedTime = Time.time - startTime;

        // Tính số phút và giây.
        int minutes = (int)(elapsedTime / 60);
        int seconds = (int)(elapsedTime % 60);

        // Hiển thị thời gian dưới dạng "00:00".
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        rightAnswerText.text="Điểm: "+ countRightAnswer+"/"+countQuestion;
        countWrongAnswerText.text="Sai: "+countWrongAnswer+"/"+countQuestion;
        if(Input.GetKeyDown(KeyCode.Return))
        {
            DeActiveDialog();
        }
        if(Input.GetKeyDown(KeyCode.M)|| Input.GetKeyDown(KeyCode.Escape))
        {
           
             SceneManager.LoadScene("Login");
            
        }    
    }
    
    public void MyAnswer(Button button)
    {
        yourAnswer =button.GetComponentInChildren<TMP_Text>().text;
        Debug.Log("answer: "+yourAnswer);
        questionPanel.SetActive(false);
        
        dialogPanel.SetActive(true);
        if (yourAnswer.ToLower()==rightAnswer.ToLower())
        {
            countRightAnswer += 1;
            player.RedKey = true;
            dialogText.text = "Câu trả lời chính xác!\n Nhấp E để mở cửa!";
        }    
        else
        {
            countWrongAnswer += 1;
            dialogText.text = "Câu trả lời không chính xác\n Hãy tìm chìa khoá!";
            player.RedKey = false;
        }
        
        
    }    
      
    public void DeActiveDialog()
    {
        dialogPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }  
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }    
    
}
