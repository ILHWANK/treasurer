using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraCh : MonoBehaviour
{
    public Camera[] cameraItem;//카메라 활성 비활성화 

    int cameraCount = 3;//카메라 갯수
    int nowCamera = 0;// 활성화된 카메라 번호

    public Text cameraText;

    public void CameraChange()
    {
        ++nowCamera;

        if (nowCamera >= cameraCount)
        {
            nowCamera = 0;
            cameraText.GetComponent<Text>().text = "1";
        }
        for (int i = 0; i < cameraItem.Length; ++i)
        {
            if (i == nowCamera)
            {
                cameraItem[i].enabled = true;
                cameraText.GetComponent<Text>().text = (i + 1).ToString();
            }
            else
            {
                cameraItem[i].enabled = false;
            }
        }
    }
}
