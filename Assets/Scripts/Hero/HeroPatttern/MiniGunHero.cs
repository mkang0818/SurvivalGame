using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public  class MiniGunHero : HeroStat
{
    public override void InitStat()
    {
        data.level = 10;

        data.MoveSp = 5;

        data.MaxHp = 10;
        data.CurHp = 10;
        data.HpRecovery = 0.5f;

        data.AttackSp = 1;
        data.AttackcoolTime = 1;
        
        data.MaxbulletCount = 30;
        data.CurbulletCount = 30;
        data.bulletCount = 5;

        data.Damage = 3;
        data.LongDamage = 3;
        data.Accuracy = 0.5f;
        data.Range = 10;
        data.defense = 3;

        data.money = 0.1f;
        data.lucky = 0.1f;
        data.Science = 0.1f;
    }

    public override void Move(GameObject player, Animator anim)
    {
        base.Move(player, anim);
    }

    public override void Dead()
    {
        base.Dead();
    }
    public override void FindEmy(Animator anim)
    {
        base.FindEmy(anim);
    }
    public override void Shot(Animator anim)
    {
        base.Shot(anim);
    }
}
