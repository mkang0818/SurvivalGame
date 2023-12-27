using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PierrotHero : HeroStat
{
    Animator anim;

    public GameObject HeelZone;
    public GameObject Turret;
    public GameObject Portal;
    GameObject PortalObj;
    public GameObject spawnHero;
    public GameObject grenadeObj;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

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
        data.ReloadCoolTime = 2;
        //공격
        data.AttackSp = 1;
        data.AttackcoolTime = 1;
        data.MoveSp = 5;

        data.Damage = 5;
        data.LongDamage = 3;
        data.Accuracy = 0.5f;
        data.Range = 10;
        data.Defense = 1;

        //세부능력
        data.HasMoney = 1;
        data.Lucky = 0.1f;
        data.Science = 0.7f;

        //스킬
        data.skillMaxTime = 1f;
        data.skillCurTime = 0;
    }
    public override void Skill()
    {
            //현재 스킬 없음
    }
    void spawnSkill()
    {
        GameObject spawnHeroObj = Instantiate(spawnHero, new Vector3(0, 0, 4), Quaternion.identity);
        PortalObj.SetActive(false);
    }
    void DodgeStart()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 lookVec = new Vector3(h, 0, v);
        transform.LookAt(transform.position + lookVec);
        data.MoveSp *= 3;
    }
    void DodgeEnd()
    {
        base.isDodge = false;
        data.MoveSp /= 3;
    }
    void PowerSkill()
    {
        data.Damage /= 2;
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
