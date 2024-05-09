using System;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    private TopDownController controller;
    private Rigidbody2D movementRigidbody;

    [SerializeField] private Camera followCamera; // 다른 클래스에서는 사용하지 않지만 인스펙터 창에서 연결시켜줘아 하므로 [SerializeFild] private 사용

    private Vector2 movementDirection = Vector2.zero; // 이동 관련 벡터값이 들어갈 변수
    private float lookDirection = 0f; // 방향 관련 실수값이 들어갈 변수

    public void Awake()
    {
        controller = GetComponent<TopDownController>();
        movementRigidbody = GetComponent<Rigidbody2D>();
        followCamera.transform.position = transform.position + new Vector3(0f, 0f, -10f);
    }

    private void Start()
    {
        controller.OnMoveEvent += Move; // 이동 관련 이벤트에 Move 메서드 추가
        controller.OnLookEvent += Look; // 방향 관련 이벤트에 Look 메서드 추가
    }
    private void FixedUpdate()
    {
        ApplyMovement(movementDirection); // 이동 방향 확정
        ApplyLookDirection(lookDirection); // 주시 방향 확정
    }

    private void LateUpdate()
    {
        ApplyCameraMovement();
    }

    private void Look(Vector2 direction) // 주시 관련 키 입력으로 변환한 실수값을 저장하는 메서드
    {
        lookDirection = direction.x;
    }

    private void ApplyLookDirection(float lookDirection) // 주시 방향을 확정시키는 메서드
    {
        if (lookDirection < 0) transform.localScale = new Vector3(-0.6f, 0.6f, 1f);
        else if (lookDirection > 0) transform.localScale = new Vector3(0.6f, 0.6f, 1f);
    }

    private void Move(Vector2 dirction) // 이동 관련 키 입력으로 변환한 방향 값을 저장하는 메서드
    {
        movementDirection = dirction;
    }


    private void ApplyMovement(Vector2 direction) // 이동 방향을 확정시키는 메서드
    {
        direction = direction * 5;
        movementRigidbody.velocity = direction;
    }

    private void ApplyCameraMovement() // 카메라 이동 확정 메서드
    {
        followCamera.transform.position = transform.position + new Vector3(0f, 0f, -10f);
    }
}