using System;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    private TopDownController controller;
    private Rigidbody2D movementRigidbody;
    private SpriteRenderer spriteRenderer;

    private Vector2 movementDirection = Vector2.zero; // 이동 관련 벡터값이 들어갈 변수
    private float lookDirection = 0f; // 방향 관련 실수값이 들어갈 변수

    public void Awake()
    {
        controller = GetComponent<TopDownController>();
        movementRigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
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

    private void Look(Vector2 direction) // 주시 관련 키 입력으로 변환한 실수값을 저장하는 메서드
    {
        lookDirection = direction.x;
    }

    private void ApplyLookDirection(float lookDirection) // 주시 방향을 확정시키는 메서드
    {
        if (lookDirection < 0) spriteRenderer.flipX = true;
        else if (lookDirection > 0) spriteRenderer.flipX = false;
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
}