using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public struct Data
{
    public int level;
    public float AttackSp;
    public float AttackcoolTime;
    public float MoveSp;
    public float MaxHp;
    public float CurHp;
    public float HpRecovery;
    public float Damage;
    public float LongDamage;
    public float ShortDamage;
}

public abstract class HeroStat : MonoBehaviour
{
    public Data data;

    [Header("Move")]
    float hAxis;
    float vAxis;
    Vector3 moveVec;
    bool isDodge;

    public List<GameObject> FoundObjects;
    public GameObject enemy;
    public float shortDis;
    public abstract void InitStat();
    public virtual void Move(GameObject player, Animator anim)
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        isDodge = Input.GetButtonDown("Dodge");

        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

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
        FoundObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));

        if (FoundObjects.Count == 0)
        {
            // 처리할 내용 (예: 적이 없는 경우 처리)
            return;
        }
        else
        {
           //if() 
           Shot(anim);
        }

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
        gameObject.transform.DOLookAt(enemy.transform.position, 0.5f);
    }
    public virtual void Shot(Animator anim)
    {
        data.AttackcoolTime -= Time.deltaTime;
        if (data.AttackcoolTime <= 0)
        {
            anim.SetTrigger("Shot");

            anim.SetTrigger("Reload");
            data.AttackcoolTime = data.AttackSp;
        }
    }
}