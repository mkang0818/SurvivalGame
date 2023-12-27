using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmyLv3 : Enemy
{
    public Animator Anim;
    GameObject target;

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

        StartCoroutine(Lv3Attack());
    }
    IEnumerator Lv3Attack()
    {
        while (true) 
        {

            transform.LookAt(this.target.transform);

            transform.position = Vector3.MoveTowards(transform.position, this.target.transform.position, Time.deltaTime * EmyStat.EmyMoveSp);
            yield return null;
        }
    }
}
