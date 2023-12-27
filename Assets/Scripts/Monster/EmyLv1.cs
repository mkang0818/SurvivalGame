using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EmyLv1 : Enemy
{
    private NavMeshAgent agent;

    public Animator Anim;

    GameObject target;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        agent.SetDestination(target.transform.position);
    }
    public override void initSetting()
    {
        EmyStat.EmyHP = 10;
        EmyStat.EmyAttack = 5;
        EmyStat.EmyMoveSp = 3;
        EmyStat.EmySkillMoveSp = 10;
    }

    public override void Attack(GameObject target)
    {
        this.target = target;
    }
}
