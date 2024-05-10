using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharaType
{
    Elf, Knight
}

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    private void Awake()
    {
        if (instance == null) instance = this;
        else return;
        DontDestroyOnLoad(gameObject);
    }

    public CharaType currentCharaType;
    public string currentPlayerName;
}
