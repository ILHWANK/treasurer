using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[RequireComponent(typeof(Button))]
public class SpeedUp : MonoBehaviour
{
    public static bool speedUp_yn = false;
    public Button SpeedUp_bt;
    public Text speedText; 
    public float timeRemaining = 5;

    private void Start()
    {
        SpeedUp_bt.GetComponent<Button>();
    }

    void Update()
    {
        if (SpeedUp_bt.interactable.Equals(false))
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining > 2) {
                speedText.GetComponent<Text>().text = ( Mathf.FloorToInt(timeRemaining) - 1).ToString();
            }
            else
            {
                speedText.GetComponent<Text>().text = "SpeedUp";
            }

        }
        if (timeRemaining <= 2 && timeRemaining > 0)
        {
            SpeedUp.speedUp_yn = false;
        }
        else if (timeRemaining <= 0)
        {
            SpeedUp_bt.interactable = true;
            timeRemaining = 5;
        } 
    }

    public void speedCtr()
    {
        if (timeRemaining.Equals(5))
        {
            SpeedUp.speedUp_yn = true;
            SpeedUp_bt.interactable = false;
        }
    }
}
