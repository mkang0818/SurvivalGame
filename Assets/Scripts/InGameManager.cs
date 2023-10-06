using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InGameManager : MonoBehaviour
{
    [HideInInspector]
    public GameObject player;
    public GameObject[] CharPrefabs = new GameObject[10];
    public GameObject StoreUI;

    public TextMeshProUGUI TxtTime;
    float Timer = 3;
    void Start()
    {
        player = Instantiate(CharPrefabs[GameManager.instance.playerNum],Vector3.zero,Quaternion.identity);
        player.GetComponent<HeroStat>().data.MoveSp = 15;
    }

    // Update is called once per frame
    void Update()
    {
        TimeManager();
    }
    void TimeManager()
    {
        Timer -= Time.deltaTime;
        TxtTime.text = ((int)Timer).ToString();

        //상점 ui 켜기
        if (Timer <= 0)
        {
            StoreUI.SetActive(true);
            print(GameObject.Find("SpawnManager").GetComponent<SpawnManager>().monsterArr[0]);
        }
    }
}
