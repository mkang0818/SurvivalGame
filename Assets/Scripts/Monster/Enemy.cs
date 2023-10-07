using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct MonsterStat {
    public float EmyHP;
    public float EmyAttack;
    public float EmyMoveSp;

}

public abstract class Enemy : MonoBehaviour
{
    public MonsterStat EmyStat;

    public abstract void initSetting();
    public abstract void Attack(GameObject target);
    public virtual void Dead(GameObject Money)
    {
        if (EmyStat.EmyHP <= 0)
        {
            Destroy(gameObject);
            Instantiate(Money, transform.position,Quaternion.identity);
        }
    }
}
