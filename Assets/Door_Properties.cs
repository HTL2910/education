using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Properties : MonoBehaviour
{
    public bool activate;
    public bool toggleState;
    public GameObject icon;

    void Update()
    {
        if (activate)
        {
            icon.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            activate = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            activate = false;
        }
    }
}
