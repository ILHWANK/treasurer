using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;//Scene을 불러 오는 경우 사용
                                  //게임 재시작등


public class GameManager : MonoBehaviour
{
    public GameObject winUI;

    public ItemBox[] itemBoxes;

    public Camera[] cameraItem;//카메라 활성 비활성화 

    int cameraCount = 3;//카메라 갯수
    int nowCamera = 0;// 활성화된 카메라 번호

    public Text cameraText;

    public bool isGameWin;
    // Start is called before the first frame update

    public void ClickButton()
    {

    }

    void Start()
    {
        isGameWin = false;
        cameraText.GetComponent<Text>().text = "1";//게임 첫 시작시 메인카메라.
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("treasurer");
        }

        if (isGameWin.Equals(true))
        {
            return;
        }

        int cnt = 0;
        for(int i = 0; i < 3; i++)
        {
            if (itemBoxes[i].isOveraped.Equals(true))
            {
                cnt++;
            }
        }

        if (cnt >= 3)
        {
            isGameWin = true;
            winUI.SetActive(true);
            // 자기 자신을 보였다 안보였다 할 수 있다!
        }

        if (Input.GetButtonUp("Fire3"))//카메라 시점 전환 left shit
        {
            ++nowCamera;

            if (nowCamera >= cameraCount)
            {
                nowCamera = 0;
                cameraText.GetComponent<Text>().text = "1";
            }
            for (int i = 0; i < cameraItem.Length; ++i)
            {
                if(i == nowCamera)
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
}
