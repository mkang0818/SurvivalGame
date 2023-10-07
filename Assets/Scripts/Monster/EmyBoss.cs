using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmyBoss : Enemy
{
    public Animator Anim;
    GameObject target;

    public override void initSetting()
    {
        EmyStat.EmyHP = 1;
        EmyStat.EmyAttack = 1;
        EmyStat.EmyMoveSp = 1;
    }
    public override void Attack(GameObject target)
    {
        this.target = target;
        transform.LookAt(target.transform);

        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * EmyStat.EmyMoveSp);
    }
}
