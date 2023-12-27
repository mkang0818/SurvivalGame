using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public  class PierrotHero : HeroStat
{
    public override void InitStat()
    {
        //레벨
        data.level = 10;
        data.MaxExp = 100;
        data.CurExp = 0;

        //생명
        data.MaxHp = 10;
        data.CurHp = 10;
        data.HpRecovery = 0.5f;

        //총알 수
        data.MaxbulletCount = 30;
        data.CurbulletCount = 30;
        data.bulletCount = 5;
        data.ReloadTime = 2;

        //공격
        data.AttackSp = 1;
        data.AttackcoolTime = 1;
        data.MoveSp = 5;

        data.Damage = 3;
        data.LongDamage = 3;
        data.Accuracy = 0.5f;
        data.Range = 10;
        data.Defense = 1;

        //세부능력
        data.HasMoney = 1;
        data.Lucky = 0.1f;
        data.Science = 0.1f;

        //스킬
        data.skillMaxTime = 8f;
        data.skillCurTime = 8f;
    }
    public override void Skill()
    {

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
