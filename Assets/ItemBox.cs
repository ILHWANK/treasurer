using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public bool isOveraped = false;

    private Renderer myRenderer;

    public Color touchColor;

    public Color originalColor;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        originalColor = myRenderer.material.color;
        // 자기 자신에 있는 Renderer를 가지고 온다.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Enter은 충돌을 한순간!
    void OnTriggerEnter(Collider other)//충돌하게 되면 발동한다.
    {
        if (other.tag.Equals("EndPoint"))
        {
            isOveraped = true;
            myRenderer.material.color = touchColor;
        }
        //출동했을때 시행 할 이벤트 작성!
        //통과 가능한 충돌 인경우

    }

    //Exit 충돌이 해제 끝났을때? 실행됨
    void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("EndPoint"))
        {
            isOveraped = false;
            myRenderer.material.color = originalColor;
        }
    }

    //stay 충돌 중일때 발동함
    void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("EndPoint"))
        {
            isOveraped = true;
            myRenderer.material.color = touchColor;
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //충돌 할 경우 많은 값을 가지고 온다!
    //이번에는 있다는 것 정도만 알 고 있어도 문제 없다.
    //}
}
