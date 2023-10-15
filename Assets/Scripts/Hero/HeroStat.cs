using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public struct Data
{
    public int level; //����
    public int MaxExp; //�ְ� ����ġ
    public int CurExp; //���� ����ġ


    public float AttackSp; //���ݼӵ�
    public float AttackcoolTime; //���ݼӵ� ��Ÿ��
    public float MoveSp; //�̵��ӵ�
    public float MaxHp; //�ִ� ü��
    public float CurHp; //����ü��
    public float HpRecovery; //ȸ����

    public int MaxbulletCount; // �ִ� źâ ��
    public int CurbulletCount; //����źâ ��
    public int bulletCount; //�Ѿ˼�

    public float Damage; //���ݷ�
    public float LongDamage; //���Ÿ� ����    
    public float Accuracy; //���߷�
    public float Range; //���ݹ���
    public float defense; //����

    public float money; //��Ȯ
    public float lucky; //���
    public float Science; //���ȭ
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
    public abstract void InitStat();

    public virtual void Move(GameObject player, Animator anim)
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");

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
            // ó���� ���� (��: ���� ���� ��� ó��)
            return;
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
        gameObject.transform.DOLookAt(enemy.transform.position, data.Accuracy);

        if (shortDis < data.Range) Shot(anim);
    }
    public virtual void Shot(Animator anim)
    {
        data.AttackcoolTime -= Time.deltaTime;

        if (data.CurbulletCount > 0)
        {
            if (data.AttackcoolTime <= 0)
            {
                anim.SetTrigger("Shot");

                data.CurbulletCount -= data.bulletCount;

                data.AttackcoolTime = data.AttackSp;
            }
        }
        else
        {
            anim.SetTrigger("Reload");

            data.CurbulletCount = data.MaxbulletCount;

            data.AttackcoolTime = data.AttackSp;
        }
    }
    public virtual void LevelUp()
    {
        data.level++;
        data.AttackSp++;
        data.AttackcoolTime++;
        data.MoveSp++;
        data.MaxHp++;
        data.CurHp++;
        data.HpRecovery++;

        data.MaxbulletCount++;
        data.CurbulletCount++;
        data.bulletCount++;

        data.Damage++;
        data.LongDamage++;
        data.Accuracy++;
        data.Range++;
        data.defense++;

        data.lucky++;
    }
}