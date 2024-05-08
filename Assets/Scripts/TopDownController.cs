using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownController : MonoBehaviour // 키 입력이 감지됬을 때 호출되는 이벤트 클래스
{
    public event Action<Vector2> OnMoveEvent; // 이동 관련 입력 감지시 호출되는 이벤트 (키보드가 눌렸을 때에만 호출)
    public event Action<Vector2> OnLookEvent; // 시점 관련 입력 감지시 호출되는 이벤트 (마우스 좌표 인식이기 때문에 거의 상시 호출)

    public void CallMoveEvent(Vector2 direction) // 호출 할 이벤트 메서드에 매개변수도 같이 넘긴다.
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }
}
