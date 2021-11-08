using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public GameManager myGameManager; 

    public float speed = 10f;

    public Rigidbody playerRigidbody;
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        // 
    }

    // Update is called once per frame
    //Update 는 따로 반복 횟수는 따로 지정 X
    // 컴퓨터 또는 스마트폰 기긱의 성능에 따라 프레임 횟수가 차이 난다
    void Update()//정보를 갱신하는 느낌으로 이해 하면 좋다!
    {
        if (myGameManager.isGameWin.Equals(true))
        {
            return;
        }

        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        float fallSpped = playerRigidbody.velocity.y;



        //playerRigidbody.AddForce(inputX * speed, 0, inputZ * speed);
        //AddForce의 경우 물체에 힘을  주는 것이기때문에 관성이 존재한다(조작이 어려워짐)

        Vector3 velocity = new Vector3(inputX, 0, inputZ);
        //velocity 는 관성의 법칙이 없고 그 값만큼 움직인 다고 생각하자!
        //관성을 거치지 않기 때문에 빠르다!
        //떨어 지는 속도 쯕 중간에 y 값이 0으로 초기화 되기 때문에 천천이 떨어짐
        velocity = velocity * speed;

        velocity.y = fallSpped; 
        //천천히 떨어 지는 것을 방지 하기 위해서 원래 속도를 지정 해줌!
        playerRigidbody.velocity = velocity;


        /*
         * Input.GetAxis("Horizontal")
         * 을 상하면 코드를 많이 수정하지 않고 키입력을 수정 할 수 있고,
         * 커스텀 키를 구형 할 수 있다! 내가 원하는 기능 ㅎㅎ
         * 키보드 왼쪽 오른쪽이 할당 되어 있다.
         * 게임 할때 조이스틱 지원 해주면 너무 좋습니다. 특히 모바일 게임!
         * 키보는 왼족 오른쪽에 가각 -1, +1 로 구현 되어 있다.
         * 숫자롤 받는 이는 조이즈틱의 값을 값을 계산 하기 위해서 !
         * -1 과 +1 사이에 소숫점값을 이용하여 속도 조정 가능 하기 때문!
         */



        //if (Input.GetKey(KeyCode.W))
        //{
        //    playerRigidbody.AddForce(0, 0, speed);
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    playerRigidbody.AddForce(-speed, 0, 0);
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    playerRigidbody.AddForce(0, 0, -speed);
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    playerRigidbody.AddForce(speed, 0, 0);
        //}
        // 위 코드는 키보드 입력을 직접 받는 경우 사용!
    }
}
