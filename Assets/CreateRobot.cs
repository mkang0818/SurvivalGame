using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreateRobot : MonoBehaviour
{
    public GameObject target;

    public Animator anim;

    public HeroStat herostat;
    GameObject InGameManager;

    float HeelTime = 0.5f;
    [HideInInspector] public bool NoDamage = false;

    void Start()
    {
        herostat.InitStat();

        InGameManager = GameObject.Find("InGameManager");
        Destroy(gameObject, 10f);
    }


    void Update()
    {
        herostat.data.skillCurTime -= Time.deltaTime;
        HeelTime -= Time.deltaTime;


        herostat.Move(this.gameObject, anim);
        herostat.Dead();
        herostat.FindEmy(anim);
        if (herostat.data.skillCurTime <= 0)
        {
            herostat.Skill();
        }
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
