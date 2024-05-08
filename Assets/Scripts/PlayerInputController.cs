using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownController // 입력 값을 이벤트에 넘겨주는 클래스
{
    private Camera camera;
    private Vector2 lookInput;
    private void Awake()
    {
        camera = Camera.main;
    }
    public void OnMove(InputValue value) // Input System에서 Move 관련 입력이 감지될 때 호출 (참조가 0이어여 알아서 호출 됨.)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }

    public void OnLook(InputValue value) // Input System에서 Look 관련 입력이 감지될 때 호출 (참조가 0이여도 알아서 호출 됨.)
    {
        Vector2 screen;
        screen.x = Screen.resolutions[0].width /2;
        screen.y = Screen.resolutions[0].height /2;
        if (value.Get<Vector2>() != -screen) lookInput = value.Get<Vector2>();


    }

    private void Update()
    {
        Vector2 worldPos = camera.ScreenToWorldPoint(lookInput);
        Debug.Log(worldPos);
        lookInput = (worldPos - (Vector2)transform.position).normalized;
        CallLookEvent(lookInput);  // 캐릭터와 마우스 사이의 x축의 거리를 반환
    }
}
