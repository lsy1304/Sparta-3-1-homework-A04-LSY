using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NameInputField : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI inputName;

    public void OnPress()
    {
        if (inputName.text.Length >= 3)
        {
            DataManager.instance.currentPlayerName = inputName.text;
            SceneManager.LoadScene("MainScene");
        }
    }
}
