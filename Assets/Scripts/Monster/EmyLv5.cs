using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmyLv5 : Enemy
{
    public Animator Anim;
    GameObject target;

    public GameObject fireBall;

    float AttackCool = 5;
    float AttackCurCool = 5;
    public override void initSetting()
    {
        EmyStat.EmyHP = 1;
        EmyStat.EmyAttack = 1;
        EmyStat.EmyMoveSp = 1;
        EmyStat.EmySkillMoveSp = 10;
    }
    public override void Attack(GameObject target)
    {
        this.target = target;

        StartCoroutine(Lv5Attack());
        transform.LookAt(target.transform);

        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * EmyStat.EmyMoveSp);
    }

    IEnumerator Lv5Attack()
    {
        while (true)
        {
            AttackCurCool -= Time.deltaTime;
            if (AttackCurCool <= 0)
            {
                Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;

                for (int i=0;i<5;i++)
                {
                    Vector3 spawnPos = new Vector3(playerPos.x + Random.Range(0, 10), 5, playerPos.z + Random.Range(0, 10));
                    Instantiate(fireBall, spawnPos, Quaternion.identity);
                }
                AttackCurCool = AttackCool;
            }

            float Distance = Vector3.Distance(gameObject.transform.position, target.transform.position);

            if (Distance < 10)
            {
                Vector3 moveDir = -transform.forward;

                transform.position = Vector3.MoveTowards(transform.position, transform.position + moveDir, Time.deltaTime * EmyStat.EmyMoveSp);
            }
            else
            {
                Anim.SetBool("Walk", true);
                transform.LookAt(this.target.transform);

                transform.position = Vector3.MoveTowards(transform.position, this.target.transform.position, Time.deltaTime * EmyStat.EmyMoveSp);
            }

            yield return null;
        }
    }
}
