using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EmyLv2 : Enemy
{
    private NavMeshAgent agent;

    public Animator Anim;
    GameObject target;

    bool isFind = true;

    Vector3 lookVec;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (isFind)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            lookVec = new Vector3(h, 0, v) * 4f;
            transform.LookAt(target.transform.position + lookVec);
            
            agent.speed = 2;
            agent.SetDestination(target.transform.position);

            float Distance = Vector3.Distance(gameObject.transform.position, target.transform.position);
            if (Distance < 8)
            {
                agent.isStopped = true;
                StartCoroutine(Rush());
            }
        }
        else
        {
            Vector3 moveDir = transform.forward;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + moveDir, Time.deltaTime * 10);
        }
    }
    public override void initSetting()
    {
        EmyStat.EmyHP = 1;
        EmyStat.EmyAttack = 1;
        EmyStat.EmyMoveSp = 1;
    }
    public override void Attack(GameObject target)
    {
        this.target = target;
    }
    IEnumerator Rush()
    {
        yield return new WaitForSeconds(1f);
        isFind = false;
        yield return new WaitForSeconds(1.2f);
        isFind = true;
        agent.isStopped = false;
    }
}