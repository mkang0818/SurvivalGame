using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public  class BasicHero : HeroStat
{
    public override void InitStat()
    {
        data.level = 10;

        data.MoveSp = 5;

        data.MaxHp = 10;
        data.CurHp = 10;

        data.HpRecovery = 10;

        data.AttackSp = 1;
        data.AttackcoolTime = 1;

        data.Damage = 10;
        data.LongDamage = 10;
        data.ShortDamage = 10;

        /*
       레벨

최대hp
hp재생
생명훔침
데미지
근거리데미지
원거리데미지
원소데미지
공격속도
치명타율
엔지니어링
범위
방어구
회피
속도
행운
수확

무기
대미지
치명타
쿨타임
넉백
범위
         */
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
