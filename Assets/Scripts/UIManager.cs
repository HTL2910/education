using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
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
    

    private AN_HeroInteractive player;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        player=FindObjectOfType<AN_HeroInteractive>();
        startTime = Time.time;
        AddOnClick();
        if (questionPanel.activeSelf)
        {
            questionPanel.SetActive(false);
        }    

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
    }
    public void MyAnswer(Button button)
    {
        yourAnswer =button.GetComponentInChildren<TMP_Text>().text;
        Debug.Log("answer: "+yourAnswer);
        questionPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (yourAnswer.ToLower()==rightAnswer.ToLower())
        {

            player.RedKey = true;

        }    
        else
        {
            player.RedKey = false;
        }    
    }    
}
