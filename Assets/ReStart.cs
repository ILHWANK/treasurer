using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReStart : MonoBehaviour
{
    public void ClickButton()
    {
        SceneManager.LoadScene("treasurer");
        Debug.Log("Button Clicked");
    }
}
