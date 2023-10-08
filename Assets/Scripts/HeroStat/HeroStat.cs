using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Data
{
    public int level;
    public float AttackSp;
    public float MoveSp;
    public float MaxHp;
    public float HpRecovery;
    public float Damage;
    public float LongDamage;
    public float ShortDamage;    
}

public abstract class HeroStat : MonoBehaviour
{
    public Data data;



    public abstract void InitStat();


    public void Shot(GameObject player, GameObject bullet)
    {
        
    }
}
