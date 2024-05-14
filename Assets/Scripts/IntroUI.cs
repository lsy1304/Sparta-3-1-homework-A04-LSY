using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI inputName;
    [SerializeField] private Sprite[] sprites;

    [SerializeField] private Image image;

    public void OnPress()
    {
        if (inputName.text.Length >= 3)
        {
            DataManager.instance.currentPlayerName = inputName.text;
            SceneManager.LoadScene("MainScene");
        }
    }

    public void OnClickBtn(int num)
    {
        DataManager.instance.currentCharaType = (CharaType)num;
        image.sprite = sprites[num];
    }
}
