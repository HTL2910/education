using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Door_Properties : MonoBehaviour
{
    public bool activate;
    public bool toggleState;
    public GameObject icon;
    public bool acitvePanel=false;
    void Update()
    {
        InputNear(KeyCode.E);
    }
    protected virtual void InputNear(KeyCode keyCode)
    {
        if (activate){
            icon.SetActive(true);
            if (Input.GetKeyDown(keyCode)) {
                if (toggleState) {
                    toggleState = false;
                }else{
                    toggleState = true;
                }
            }
        }else {
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
