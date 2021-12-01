using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class MenuButton : MonoBehaviour
{
    public GameObject panel;
    public GameObject audioSound;

    public void ReStart()
    {
        SceneManager.LoadScene("treasurer");
        Debug.Log("Button Clicked");
    }
    public void SoundCtr()
    {
        if (audioSound.active.Equals(true))
            audioSound.SetActive(false);
        else
            audioSound.SetActive(true);
    }
    public void GameExit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit(); // 어플리케이션 종료
        #endif
    }

    public void PanelCtr()
    {
        if (panel.active.Equals(true))
            panel.SetActive(false);
        else
            panel.SetActive(true);
    }
}
