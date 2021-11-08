using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//Scene을 불러 오는 경우 사용
                                  //게임 재시작등

public class GameManager : MonoBehaviour
{
    public GameObject winUI;

    public ItemBox[] itemBoxes;

    public bool isGameWin;
    // Start is called before the first frame update
    void Start()
    {
        isGameWin = false;   
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
    }
}
