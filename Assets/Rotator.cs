using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(60 * Time.deltaTime,
                         60 * Time.deltaTime, 60 * Time.deltaTime);
        /*
        자기 자신의 위치를 변경 회전등..
        소문자를 사용하면 Object에 있는 기본 tranfrom을 사용 할 수 있다.
        계속해서 회전은 하지만 너무 빠른 속도로 회전한다!
        1초에 60 프레임 정도 -> 컴퓨터 또는 프로세스 성능에 따라 프레임이 다르다.
        그렇기 때문에 컴퓨터별로 프레임 회수가 다르다!
        따라서 Time.deltaTime 함수를 사용하여 프레임별 시간을 조절 한다~
        즉 1초에 60도!
         */
    }
}
