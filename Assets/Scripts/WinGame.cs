using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class WinGame : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject dialogPanel;

    void Start()
    {
        videoPlayer.loopPointReached += CheckOverPlayback;
        if(dialogPanel.activeSelf)
        {
            dialogPanel.SetActive(false);
        }    
    }

    void CheckOverPlayback(VideoPlayer vp)
    {
        ShowDialogPanel();
    }

    void ShowDialogPanel()
    {
        dialogPanel.SetActive(true);
    }
    public void Exit()
    {
        Application.Quit();
    }    
}
