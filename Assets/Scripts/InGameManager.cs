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
    float Timer = 30;
    
    [HideInInspector]
    public int StageNum = 1;

    public TextMeshProUGUI TxtMoney;
    public int money;
    void Start()
    {
        player = Instantiate(CharPrefabs[GameManager.instance.playerNum],Vector3.zero,Quaternion.identity);
        //player.GetComponent<HeroStat>().data.MoveSp = 15;
    }

    // Update is called once per frame
    void Update()
    {
        TimeManager();
        MoneyUpdate();
    }
    void MoneyUpdate()
    {
        TxtMoney.text = money.ToString();
    }
    void TimeManager()
    {
        Timer -= Time.deltaTime;
        TxtTime.text = ((int)Timer).ToString();

        StageNum += 1;
        //상점 ui 켜기
        if (Timer <= 0)
        {
            StoreUI.SetActive(true);
        }
    }
}
