using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownController // �Է� ���� �̺�Ʈ�� �Ѱ��ִ� Ŭ����
{
    private Camera camera;
    private Vector2 lookInput;
    private void Awake()
    {
        camera = Camera.main;
    }
    public void OnMove(InputValue value) // Input System���� Move ���� �Է��� ������ �� ȣ�� (������ 0�̾ �˾Ƽ� ȣ�� ��.)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }

    public void OnLook(InputValue value) // Input System���� Look ���� �Է��� ������ �� ȣ�� (������ 0�̿��� �˾Ƽ� ȣ�� ��.)
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
        CallLookEvent(lookInput);  // ĳ���Ϳ� ���콺 ������ x���� �Ÿ��� ��ȯ
    }
}
