using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public struct Data
{
    public int level; //����
    public int MaxExp; //�ְ� ����ġ
    public int CurExp; //���� ����ġ

    public float MaxHp; //�ִ� ü��
    public float CurHp; //����ü��
    public float HpRecovery; //ȸ����

    public int MaxbulletCount; // �ִ� źâ ��
    public int CurbulletCount; //����źâ ��
    public int bulletCount; //�Ѿ˼�
    public float ReloadTime; //������ �ӵ�
    public float ReloadCoolTime; //������ ��Ÿ��

    public float AttackSp; //���ݼӵ�
    public float AttackcoolTime; //���ݼӵ� ��Ÿ��
    public float MoveSp; //�̵��ӵ�

    public float Damage; //���ݷ�
    public float LongDamage; //���Ÿ� ����    
    public float Accuracy; //���߷�
    public float Range; //���ݹ���
    public float Defense; //����

    public int HasMoney; //��Ȯ
    public float Lucky; //���
    public float HasExp; //����ġȹ��
    public float Science; //���ȭ

    public float skillMaxTime; //��ų ��Ÿ��
    public float skillCurTime; //��ų ���� ��Ÿ��
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
            // ó���� ���� (��: ���� ���� ��� ó��)
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
                    print("�߻�");
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


            print("������");
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