using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmyLv4 : Enemy
{
    public Animator Anim;
    GameObject target;
    public override void initSetting()
    {
        EmyStat.EmyHP = 1;
        EmyStat.EmyAttack = 1;
        EmyStat.EmyMoveSp = 3;
    }
    public override void Attack(GameObject target)
    {
        this.target = target;
        StartCoroutine(Lv4Attack());
    }
    IEnumerator Lv4Attack()
    {
        while (true)
        {
            float Distance = Vector3.Distance(gameObject.transform.position, target.transform.position);

            if (Distance < 10)
            {
                Vector3 moveDir = - transform.forward;

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
