using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent agent;

    public Enemy Emy;
    GameObject target;

    public GameObject MoneyPrefab;

    [HideInInspector]
    public float hp = 5f;

    [HideInInspector] public bool IsSlowTime = false;

    float CurslowTime = 3;
    float MaxslowTime = 3;


    public GameObject hitEffect;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");

        agent = GetComponent<NavMeshAgent>();

        Emy.initSetting();
        Emy.Attack(target);
    }

    // Update is called once per frame
    void Update()
    {
        Emy.Dead(MoneyPrefab);

        SlowTime();
    }
    void SlowTime()
    {
        if (IsSlowTime)
        {
            CurslowTime -= Time.deltaTime;

            if (CurslowTime <= 0)
            {
                Emy.EmyStat.EmySkillMoveSp = 7f;
                agent.speed = 3f;

                IsSlowTime = false;
                CurslowTime = MaxslowTime;
            }

            Emy.EmyStat.EmySkillMoveSp = 3.5f;
            agent.speed = 1f;
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("AttackPos"))
        {
            print("사무라이공격");
            Emy.EmyStat.EmyHP -= target.GetComponent<PlayerController>().herostat.data.Damage;

            GameObject hiteffect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(hiteffect, 0.2f);
        }
        else if (col.gameObject.CompareTag("Bullet"))
        {
            col.gameObject.GetComponent<BulletController>().BulletcurHP -= 1;
            Emy.EmyStat.EmyHP -= target.GetComponent<PlayerController>().herostat.data.Damage;
        }

        if (col.gameObject.CompareTag("Player"))
        {
            bool isEvasion = RandomEvasion(col.GetComponent<PlayerController>().herostat.data.Lucky);

            if (isEvasion)
            {
                print("회피!!");
            }
            else
            {
                if (!col.GetComponent<PlayerController>().NoDamage)
                {
                    col.GetComponent<PlayerController>().herostat.data.CurHp -= (int)(Emy.EmyStat.EmyAttack - (0.5 * col.GetComponent<HeroStat>().data.Defense));
                }
            }
        }
    }
    bool RandomEvasion(float persent)
    {
        float randomValue = Random.value;
        return randomValue <= persent;
    }
}