using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class JoyStick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{

    public RectTransform joyStickBG;                // 조이스틱 배경 이미지
    public RectTransform joyStickButton;            // 조이스틱 이미지

    public Transform targetPlayer;                    // 움직일 타겟

    Vector2 stickVector;                            // 스틱의 움직인 벡터 값
    Vector3 smoothVelocity;                         // SmoothDamp 3번째 인자값

    IEnumerator currCoroutine;                      // 현재 진행중인 코루틴 (OnJoyStickReset 정지하기 위해 사용)

    float smoothTime = 0.2f;                        // 스틱이 제자리로 돌아오는 시간 
    float smoothSpeed = 10.0f;                      // 스틱이 돌아오는 속도
    float inverseSmoothSpeed = 0f;                  // 곱연산을 하기위한 역수
    float bgRadius = 0f;                            // 조이스틱 배경 이미지의 반지름
    float stickDistRatio = 0f;                      // 스틱이 움직인 거리 비율
    float moveSpeed = 5f;                           // 타겟의 이동 속도
    float rotSpeed = 10f;                           // 타겟의 회전 속도

    bool isReturn = false;                          // 스틱이 돌아오는 함수 실행중인지 판단하는 변수
    bool canMove = false;                           // 스틱을 움직이고 있는지 판단하는 변수

    // Start is called before the first frame update
    void Start()
    {
        bgRadius = joyStickBG.rect.width * 0.25f;
        inverseSmoothSpeed = 1 / smoothSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        MoveAndRotate();
    }

    // Target의 이동 및 회전
    void MoveAndRotate()
    {
        if (!canMove) return;

        // 이동
        Vector2 normalVec = stickVector.normalized;
        targetPlayer.position += new Vector3(normalVec.x, 0, normalVec.y) * stickDistRatio * moveSpeed * Time.deltaTime;

        // 회전
        Vector3 newRot = Vector3.up * Mathf.Atan2(normalVec.x, normalVec.y) * Mathf.Rad2Deg;
        targetPlayer.rotation = Quaternion.Lerp(targetPlayer.rotation, Quaternion.Euler(newRot), rotSpeed * Time.deltaTime);
    }

    // 마우스 클릭 위치에 따른 조이스틱의 이동
    void OnJoyStickMove(Vector2 pointerPos)
    {
        if (isReturn)
        {
            StopCoroutine(currCoroutine);
            isReturn = false;
        }

        // 클릭 위치가 중앙으로부터 얼마나 떨어져있는지 계산 후
        // 배경 이미지의 크기를 넘어가지 않도록 제한
        stickVector = new Vector2(pointerPos.x - joyStickBG.position.x, pointerPos.y - joyStickBG.position.y);
        stickVector = Vector2.ClampMagnitude(stickVector, bgRadius);

        joyStickButton.localPosition = stickVector;

        // 조이스틱의 위치와 배경 이미지의 반지름 비율
        stickDistRatio = (joyStickBG.position - joyStickButton.position).sqrMagnitude / (bgRadius * bgRadius);
    }

    // 조이스틱이 초기 위치로 돌아옴
    IEnumerator OnJoyStickReset()
    {
        isReturn = true;

        float time = Time.time;

        while (Time.time < time + smoothTime)
        {
            joyStickButton.position = Vector3.SmoothDamp(joyStickButton.position, joyStickBG.position, ref smoothVelocity, inverseSmoothSpeed);
            yield return null;
        }

        isReturn = false;
        joyStickButton.position = joyStickBG.position;
    }

    // 마우스 클릭할 때 이벤트 발생
    public void OnPointerDown(PointerEventData eventData)
    {
        canMove = true;
        OnJoyStickMove(eventData.position);
    }

    // 마우스 누르고 있을 때 이벤트 발생
    public void OnDrag(PointerEventData eventData)
    {
        OnJoyStickMove(eventData.position);
    }

    // 마우스 클릭 끝날 때 이벤트 발생
    public void OnPointerUp(PointerEventData eventData)
    {
        canMove = false;

        // 손 놨을 때 원래 자리로 이동
        currCoroutine = OnJoyStickReset();
        StartCoroutine(currCoroutine);
    }
}
