using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacter : MonoBehaviour
{
    [SerializeField] private GameObject charaBtn;
    public CharaType charaType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OnClick()
    {
        DataManager.instance.currentCharaType = charaType;
        charaBtn.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }
}
