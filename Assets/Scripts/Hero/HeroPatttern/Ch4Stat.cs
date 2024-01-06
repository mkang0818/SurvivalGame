using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Ch4Stat : HeroStat
{
    Animator anim;

    public GameObject HeelZone;
    public GameObject Turret;
    public GameObject Portal;
    GameObject PortalObj;
    public GameObject spawnHero;
    public GameObject grenadeObj;


    public GameObject AttackPos;
    public GameObject hitEffect;

    bool isDash = false;
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
        //Dash - H4
        if (data.skillCurTime <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space) && transform.position != Vector3.zero)
            {
                isDash = true;
                anim.SetTrigger("Dash");
                if (isDash)
                {
                    Invoke("DashStart", 0.1f);
                }
                Invoke("DashEnd", 0.5f);
                data.skillCurTime = data.skillMaxTime;
            }
        }
    }
    void DashStart()
    {
        /*float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 lookVec = new Vector3(h, 0, v);
        transform.LookAt(transform.position + lookVec);*/
        data.MoveSp *= 4;
    }
    void DashEnd()
    {
        isDash = false;
        data.MoveSp /= 4;
    }
    public override void Move(GameObject player, Animator anim)
    {
        base.Move(player, anim);
    }

    public override void Dead()
    {
        base.Dead();
    }
    public override void LookMouseCursor()
    {
        base.LookMouseCursor();
    }
    public override void FindEmy(Animator anim)
    {
        base.FindEmy(anim);
    }
    public override void Shot(Animator anim)
    {
        data.AttackcoolTime -= Time.deltaTime;

        if (data.AttackcoolTime <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetTrigger("Shot");
                AttackPos.SetActive(true);
                data.CurbulletCount -= data.bulletCount;

                data.AttackcoolTime = data.AttackSp;
                Invoke("AttackOff",0.2f);
            }
        }
    }
    void AttackOff()
    {
        AttackPos.SetActive(false);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.transform.CompareTag("Enemy"))
        {
            if (isDash)
            {
                col.gameObject.GetComponent<EnemyController>().Emy.EmyStat.EmyHP -= data.Damage;

                GameObject hiteffect = Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(hiteffect, 0.2f);
            }
        }
    }
}
