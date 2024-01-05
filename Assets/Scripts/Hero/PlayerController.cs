using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Animator anim;

    public HeroStat herostat;
    GameObject InGameManager;

    Slider hpBar;
    Slider expBar;
    Text TxtBulletCount;

    float HeelTime = 0.5f;
    [HideInInspector] public bool NoDamage = false;

    public bool isStart = false;
    void Start()
    {
        herostat.InitStat();

        InGameManager = GameObject.Find("InGameManager");
        hpBar = GameObject.Find("UI").transform.Find("HPSlider").GetComponent<Slider>();
        expBar = GameObject.Find("UI").transform.Find("EXPSlider").GetComponent<Slider>();
        TxtBulletCount = GameObject.Find("UI").transform.Find("TxtBulletCount").GetComponent<Text>();

        hpBar.value = herostat.data.CurHp / herostat.data.MaxHp;
        expBar.value = herostat.data.CurHp / herostat.data.MaxHp;
    }


    void Update()
    {
        if (isStart)
        {
            UpdateHP();

            herostat.data.skillCurTime -= Time.deltaTime;
            HeelTime -= Time.deltaTime;


            herostat.Move(this.gameObject, anim);
            herostat.LookMouseCursor();
            herostat.Dead();
            herostat.Shot(anim);
            if (herostat.data.skillCurTime <= 0)
            {
                herostat.Skill();
            }

            TxtBulletCount.text = herostat.data.CurbulletCount + " / " + herostat.data.MaxbulletCount;
        }
    }

    void UpdateHP()
    {
        herostat.data.CurHp += herostat.data.HpRecovery;

        hpBar.value = Mathf.Lerp(hpBar.value, herostat.data.CurHp / herostat.data.MaxHp, Time.deltaTime * 10);
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Money"))
        {
            Destroy(col.gameObject);
            herostat.data.CurHp += herostat.data.HpRecovery;
            InGameManager.GetComponent<InGameManager>().money += herostat.data.HasMoney;

            /*Collider[] coll = Physics.OverlapSphere(col.transform.position, herostat.data.Lucky, 6);
            
            if(coll != null) print(coll[0].gameObject); Destroy(coll[0].gameObject);*/
        }

        
    }
    private void OnTriggerStay(Collider col)
    {
        //SkillItem
        if (col.gameObject.CompareTag("HeelZone"))
        {
            if (HeelTime <= 0)
            {
                herostat.data.CurHp += 1;
                HeelTime = 0.5f;
            }            
        }
    }
}
