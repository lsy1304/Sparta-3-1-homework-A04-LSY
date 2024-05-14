using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReselectCharacter : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;

    private Image spriteRenderer;
    private bool isSelected = false; // ù ���� ����
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = transform.GetChild(0).GetComponent<Image>();
    }

    private void OnEnable() // ����� �̹� �����ִ� ��� �⺻������ �ѹ� ����
    {
        if(isSelected) spriteRenderer.sprite = sprites[(int)DataManager.instance.currentCharaType]; 
        else isSelected = true; // ù ���� null�̹Ƿ� ����
    }
}
