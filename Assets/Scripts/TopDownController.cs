using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownController : MonoBehaviour // Ű �Է��� �������� �� ȣ��Ǵ� �̺�Ʈ Ŭ����
{
    public event Action<Vector2> OnMoveEvent; // �̵� ���� �Է� ������ ȣ��Ǵ� �̺�Ʈ (Ű���尡 ������ ������ ȣ��)
    public event Action<Vector2> OnLookEvent; // ���� ���� �Է� ������ ȣ��Ǵ� �̺�Ʈ (���콺 ��ǥ �ν��̱� ������ ���� ��� ȣ��)

    public void CallMoveEvent(Vector2 direction) // ȣ�� �� �̺�Ʈ �޼��忡 �Ű������� ���� �ѱ��.
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }
}
