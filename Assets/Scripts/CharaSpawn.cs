using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharaSpawn : MonoBehaviour
{
    public GameObject[] prefabList;
    public GameObject player;
    public TextMeshProUGUI playerName;
    // Start is called before the first frame update
    void Awake()
    {
        player = Instantiate(prefabList[(int)DataManager.instance.currentCharaType]);
        player.transform.SetParent(GameObject.Find("Player").transform);
        player.transform.localPosition = Vector3.zero;
        playerName.text = DataManager.instance.currentPlayerName;
        Debug.Log(playerName.text);
    }
}
