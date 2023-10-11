using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmyLv6 : Enemy
{
    public Animator Anim;
    GameObject target;

    float Rushcooltime = 3;
    bool rush;
    public override void initSetting()
    {
        EmyStat.EmyHP = 1;
        EmyStat.EmyAttack = 1;
        EmyStat.EmyMoveSp = 1;
    }
    public override void Attack(GameObject target)
    {
        this.target = target;
        StartCoroutine(Lv6Attack());
    }
    IEnumerator Lv6Attack()
    {
        while (true)
        {
            float Distance = Vector3.Distance(gameObject.transform.position, target.transform.position);

            if (Distance < 10)
            {
                Rushcooltime -= Time.deltaTime;

                Vector3 moveDir = transform.forward;
                transform.position = Vector3.MoveTowards(transform.position, transform.position + moveDir, Time.deltaTime * 10);

                if (Rushcooltime <= 0)
                {
                    rush = false;
                }
                else rush = true;

            }
            else
            {
                if (!rush)
                {
                    Anim.SetBool("Walk", true);
                    transform.LookAt(target.transform);

                    transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * EmyStat.EmyMoveSp);
                }
            }

            yield return null;
        }
    }
}
