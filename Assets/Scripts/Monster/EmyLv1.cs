using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmyLv1 : Enemy
{
    public Animator Anim;

    GameObject target;

    public override void initSetting()
    {
        EmyStat.EmyHP = 10;
        EmyStat.EmyAttack = 5;
        EmyStat.EmyMoveSp = 3;
    }

    public override void Attack(GameObject target)
    {
        this.target = target;

        StartCoroutine(Lv1Attack());
    }

    IEnumerator Lv1Attack()
    {
        while (true)
        {
            Anim.SetBool("Walk", true);
            transform.LookAt(this.target.transform);

            transform.position = Vector3.MoveTowards(transform.position, this.target.transform.position, Time.deltaTime * EmyStat.EmyMoveSp);
            yield return null;
        }
    }

}
