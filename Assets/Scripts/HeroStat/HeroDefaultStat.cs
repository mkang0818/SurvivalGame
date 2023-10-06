using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public  class HeroDefaultStat : HeroStat
{

    public override void InitStat()
    {
        data.level = 1;
        data.AttackSp = 1;
        data.MoveSp = 1;
        data.MaxHp = 1;
        data.HpRecovery = 1;
        data.Damage = 1;
        data.LongDamage = 1;
        data.ShortDamage = 1;
    }
}
