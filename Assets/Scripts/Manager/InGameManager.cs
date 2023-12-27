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

    public GameObject[] SpawnObj = new GameObject[7];

    public TextMeshProUGUI TxtStage;
    public TextMeshProUGUI TxtTime;
    float Timer = 60;
    
    [HideInInspector]
    public int StageNum = 1;

    public TextMeshProUGUI TxtMoney;
    public int money;
    void Start()
    {
        player = Instantiate(CharPrefabs[GameManager.instance.playerNum],Vector3.zero,Quaternion.identity);

        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerController>().isStart)
        {
            TimeManager();
            MoneyUpdate();
        }
    }
    void Spawn()
    {
        switch (StageNum)
        {
            case 1:
                SpawnObj[0].SetActive(true);
                break;
            case 3:
                SpawnObj[1].SetActive(true);
                break;
            case 6:
                SpawnObj[2].SetActive(true);
                break;
            case 9:
                SpawnObj[3].SetActive(true);
                break;
            case 11:
                SpawnObj[4].SetActive(true);
                break;
            case 14:
                SpawnObj[5].SetActive(true);
                break;
            case 20:
                print("보스 출현");
                break;
        }
    }
    void MoneyUpdate()
    {
        TxtMoney.text = money.ToString();
    }
    void TimeManager()
    {
        Timer -= Time.deltaTime;
        TxtStage.text = StageNum.ToString() + "Stage";
        TxtTime.text = ((int)Timer).ToString();

        //상점 ui 켜기
        if (Timer <= 0)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
            }
            player.transform.position = Vector3.zero;

            for (int i = 0; i < StageNum; i++)
            {
                SpawnObj[i].SetActive(false);
            }

            for(int i=0;i<6;i++) SpawnObj[i].SetActive(false);


            StoreUI.SetActive(true);
        }
    }
    public void Reroll()
    {

    }
    public void nextStage()
    {
        StoreUI.SetActive(false);
        Timer = 30;
        StageNum += 1;

        Spawn();
    }
    public void Get1Btn()
    {

    }
    public void Get2Btn()
    {

    }
    public void Get3Btn()
    {

    }
    public void Get4Btn()
    {

    }
}
