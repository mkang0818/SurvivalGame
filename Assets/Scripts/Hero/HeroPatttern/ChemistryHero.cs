using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChemistryHero : HeroStat
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
        //HeelPack-H1
        /*if (data.skillCurTime <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject HeelPack = Instantiate(HeelZone, transform.position, Quaternion.identity);

                data.skillCurTime = data.skillMaxTime;
                Destroy(HeelPack, 5f);
            }
        }*/

        //Invincible 무적 - H13
        /*if (data.skillCurTime <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<PlayerController>().NoDamage = true;
                data.skillCurTime = data.skillMaxTime;

                Invoke("InitSkill", 3f);
            }
        }*/
        //SlowTimer - H10
        /*if (data.skillCurTime <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                for (int i = 0; i < enemies.Length; i++)
                {
                    enemies[i].GetComponent<EnemyController>().IsSlowTime = true;
                }
                data.skillCurTime = data.skillMaxTime;
            }
        }*/

        //Turret - H8
        /*if (data.skillCurTime <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                float Xpos = Random.Range(-6.5f, 6.5f);
                float Zpos = Random.Range(-6.5f, 6.5f);

                GameObject TurretObj = Instantiate(Turret, new Vector3(Xpos,0,Zpos), Quaternion.identity);
                TurretObj.GetComponent<TurretController>().turretLevel = data.Science;

                data.skillCurTime = data.skillMaxTime;
            }
        }*/

        //Dodge - H5
        /*if (data.skillCurTime <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space) && transform.position != Vector3.zero)
            {
                base.isDodge = true; 
                anim.SetTrigger("IsDodge");
                if (base.isDodge)
                {
                    Invoke("DodgeStart", 0.3f);
                }        
                Invoke("DodgeEnd", 0.6f);
                data.skillCurTime = data.skillMaxTime;
            }
        }*/

        //SpawnHero - H12
        if (data.skillCurTime <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PortalObj = Instantiate(Portal, new Vector3(0, 1.2f, 4), Quaternion.identity);

                Invoke("spawnSkill", 2f);
                data.skillCurTime = data.skillMaxTime;
            }
        }
        //StrongHero - H11
        /*if (data.skillCurTime <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                data.Damage *= 2;

                Invoke("PowerSkill", 10f);
                data.skillCurTime = data.skillMaxTime;
            }
        }*/
        //BombHero - H13 Attack
        /*if (data.skillCurTime <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit rayHit;
                if (Physics.Raycast(ray,out rayHit, 100))
                {
                    Vector3 nextVec = rayHit.point - transform.position;
                    nextVec.y = 2; //나가는 거리 변수

                    Vector3 playerPos = new Vector3(transform.position.x, transform.position.y+0.5f, transform.position.z);
                    GameObject instantGrenade = Instantiate(grenadeObj, playerPos, Quaternion.identity);
                    Rigidbody rigidGrenade = instantGrenade.GetComponent<Rigidbody>();
                    rigidGrenade.AddForce(nextVec,ForceMode.Impulse);
                    rigidGrenade.AddTorque(Vector3.back*10,ForceMode.Impulse);

                    gameObject.transform.DOLookAt(nextVec, 1f);
                }

                data.skillCurTime = data.skillMaxTime;
            }
        }*/
        //MoneyHero - H2
        /*if (data.skillCurTime <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                data.HasMoney *= 3;

                Invoke("spawnSkill", 2f);
                data.skillCurTime = data.skillMaxTime;
            }
        }*/
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
