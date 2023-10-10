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

    public TextMeshProUGUI TxtStage;
    public TextMeshProUGUI TxtTime;
    float Timer = 20;
    
    [HideInInspector]
    public int StageNum = 1;

    public TextMeshProUGUI TxtMoney;
    public int money;
    void Start()
    {
        player = Instantiate(CharPrefabs[GameManager.instance.playerNum],Vector3.zero,Quaternion.identity);
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
