using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public struct Data
{
    public int level; //레벨
    public int MaxExp; //최고 경험치
    public int CurExp; //현재 경험치

    public float MaxHp; //최대 체력
    public float CurHp; //현재체력
    public float HpRecovery; //회복력

    public int MaxbulletCount; // 최대 탄창 수
    public int CurbulletCount; //현재탄창 수
    public int bulletCount; //총알수
    public float ReloadTime; //재장전 속도
    public float ReloadCoolTime; //재장전 쿨타임

    public float AttackSp; //공격속도
    public float AttackcoolTime; //공격속도 쿨타임
    public float MoveSp; //이동속도

    public float Damage; //공격력
    public float LongDamage; //원거리 공격    
    public float Accuracy; //명중률
    public float Range; //공격범위
    public float Defense; //방어력

    public int HasMoney; //수확
    public float Lucky; //행운
    public float HasExp; //경험치획득
    public float Science; //기계화

    public float skillMaxTime; //스킬 쿨타임
    public float skillCurTime; //스킬 현재 쿨타임
}

public abstract class HeroStat : MonoBehaviour
{
    public Data data;

    [Header("Move")]
    float hAxis;
    float vAxis;
    Vector3 moveVec;

    public List<GameObject> FoundObjects;
    public GameObject enemy;
    public float shortDis;

    public bool isDodge = false;

    public abstract void InitStat();
    public abstract void Skill();

    public virtual void Move(GameObject player, Animator anim)
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");

        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        //player.transform.rotation = Quaternion.Lerp(player.transform.rotation, Quaternion.LookRotation(moveVec), Time.deltaTime * 4);
        player.transform.position += moveVec * data.MoveSp * Time.deltaTime;

        anim.SetBool("Run", moveVec != Vector3.zero);
    }
    public virtual void Dead()
    {
        if (data.CurHp <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
    public virtual void FindEmy(Animator anim)
    {
        /*FoundObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));

        if (FoundObjects.Count == 0)
        {
            // 처리할 내용 (예: 적이 없는 경우 처리)
            Vector3 lookVec = new Vector3(hAxis, 0, vAxis);
            transform.LookAt(transform.position + lookVec);
        }
        else
        {
            shortDis = Vector3.Distance(gameObject.transform.position, FoundObjects[0].transform.position);

            enemy = FoundObjects[0];

            foreach (GameObject found in FoundObjects)
            {
                float Distance = Vector3.Distance(gameObject.transform.position, found.transform.position);

                if (Distance < shortDis)
                {
                    enemy = found;
                    shortDis = Distance;
                }
            }

            if (!isDodge) gameObject.transform.DOLookAt(enemy.transform.position, data.Accuracy);

            if (shortDis < data.Range) Shot(anim);
        }*/
    }
    public virtual void LookMouseCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitResult;
        if (Physics.Raycast(ray, out hitResult))
        {
            Vector3 mouseDir = new Vector3(hitResult.point.x, transform.position.y, hitResult.point.z) - transform.position;
            transform.forward = mouseDir;
        }
    }
    public virtual void Shot(Animator anim)
    {
        data.AttackcoolTime -= Time.deltaTime;

        if (data.CurbulletCount > 0)
        {
            if (data.AttackcoolTime <= 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    print("발사");
                    anim.SetTrigger("Shot");
                }
            }
        }
        else
        {
            anim.SetTrigger("Reload");
            data.ReloadCoolTime -= Time.deltaTime;

            Image ReloadGauge = GameObject.Find("UI").transform.Find("ReloadGauge").GetComponent<Image>();
            ReloadGauge.fillAmount = 1.0f - (Mathf.Lerp(0, 100, data.ReloadCoolTime / data.ReloadTime) / 100);


            print("장전중");
            if (data.ReloadCoolTime < 0)
            {
                data.CurbulletCount = data.MaxbulletCount;

                data.ReloadCoolTime = data.ReloadTime;
                data.AttackcoolTime = data.AttackSp;
            }
        }
    }
    public virtual void LevelUp()
    {
        //Stat Upgrade
    }
}