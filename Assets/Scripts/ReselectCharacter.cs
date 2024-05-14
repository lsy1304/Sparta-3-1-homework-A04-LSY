using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReselectCharacter : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;

    private Image spriteRenderer;
    private bool isSelected = false; // 첫 진입 방지
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = transform.GetChild(0).GetComponent<Image>();
    }

    private void OnEnable() // 실행시 이미 켜져있는 경우 기본적으로 한번 실행
    {
        if(isSelected) spriteRenderer.sprite = sprites[(int)DataManager.instance.currentCharaType]; 
        else isSelected = true; // 첫 값은 null이므로 무시
    }
}
