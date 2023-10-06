using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public  class HeroDefaultStat1 : HeroStat
{

    public override void InitStat()
    {
        data.level = 10;
        data.AttackSp = 10;
        data.MoveSp = 10;
        data.MaxHp = 10;
        data.HpRecovery = 10;
        data.Damage = 10;
        data.LongDamage = 10;
        data.ShortDamage = 10;
    }
}
