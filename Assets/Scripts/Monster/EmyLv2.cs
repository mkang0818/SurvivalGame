using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmyLv2 : Enemy
{
    public Animator Anim;
    GameObject target;

    bool waitCheck = true;
    public override void initSetting()
    {
        EmyStat.EmyHP = 1;
        EmyStat.EmyAttack = 1;
        EmyStat.EmyMoveSp = 1;
    }
    public override void Attack(GameObject target)
    {
        this.target = target;

        StartCoroutine(Lv2Attack());
    }
    IEnumerator Lv2Attack()
    {
        while (true)
        {
            float Distance = Vector3.Distance(gameObject.transform.position, target.transform.position);

            if (Distance < 10)
            {
                Vector3 moveDir = transform.forward;
                transform.position = Vector3.MoveTowards(transform.position, transform.position + moveDir, Time.deltaTime * 25);
            }
            else
            {
                Anim.SetBool("Walk", true);
                transform.LookAt(target.transform);

                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * EmyStat.EmyMoveSp);
            }
            yield return null;
        }
    }
}