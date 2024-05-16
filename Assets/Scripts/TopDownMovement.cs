using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    private TopDownController controller;
    private Rigidbody2D movementRigidbody;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private Camera followCamera; // 다른 클래스에서는 사용하지 않지만 인스펙터 창에서 연결시켜줘아 하므로 [SerializeFild] private 사용

    private Vector2 movementDirection = Vector2.zero; // 이동 관련 벡터값이 들어갈 변수
    private Vector2 lookDirection = Vector2.zero; // 방향 관련 실수값이 들어갈 변수

    private void Start()
    {
        controller = GetComponent<TopDownController>();
        movementRigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = transform.GetChild(1).GetComponent<SpriteRenderer>();
        followCamera.transform.position = transform.position + new Vector3(0f, 0f, -10f);

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
        lookDirection = direction;
    }

    private void ApplyLookDirection(Vector2 lookDirection) // 주시 방향을 확정시키는 메서드
    {
        float rotZ = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg; // 각도를 찾는 방법
        spriteRenderer.flipX = Mathf.Abs(rotZ) > 90;
        //Debug.Log(lookDirection < 0);
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