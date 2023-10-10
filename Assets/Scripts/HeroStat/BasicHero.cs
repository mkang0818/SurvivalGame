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
       ����

�ִ�hp
hp���
������ħ
������
�ٰŸ�������
���Ÿ�������
���ҵ�����
���ݼӵ�
ġ��Ÿ��
�����Ͼ
����
��
ȸ��
�ӵ�
���
��Ȯ

����
�����
ġ��Ÿ
��Ÿ��
�˹�
����
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
