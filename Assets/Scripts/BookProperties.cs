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
                Debug.Log("active");
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
