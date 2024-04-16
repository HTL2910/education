using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookProperties : MonoBehaviour
{
    public bool activate;
    public GameObject icon;
    private void Start()
    {
        icon=gameObject.transform.GetChild(0).transform.GetChild(0).gameObject;
    }
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
                UIManager ui = UIManager.instance;
                ui.knowdelgePanel.SetActive(true);
                int randomIndex = Random.Range(0, ui.listSprite.Count);
                ui.knowdelgeImage.sprite = ui.listSprite[randomIndex];
                if (ui.listText[randomIndex] != string.Empty)
                {
                    ui.knowdelgeText.text = ui.listText[randomIndex];
                }
                else
                {
                    ui.knowdelgeText.text = "Sự thú vị của các con số";
                }

                ui.listText.RemoveAt(randomIndex);
                ui.listSprite.RemoveAt(randomIndex);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
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
        }
    }
    protected void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            activate = false;
        }
    }
}
