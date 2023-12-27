using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TurretController : MonoBehaviour
{
    [HideInInspector] public float turretLevel;
    public float CurHP;
    public float MaxHP;
    float AttackSp = 2;
    float CurAttackSp = 2;
    float range = 5f;

    public Transform TurretHead;
    public Transform ShotPos;
    public GameObject BulletPrefab;

    public List<GameObject> FoundObjects;
    public GameObject enemy;
    public float shortDis;
    PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        FindEmy();

        Dead();
    }
    void FindEmy()
    {
        FoundObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));

        if (FoundObjects.Count == 0)
        {
            // 처리할 내용 (예: 적이 없는 경우 처리)
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
        print(enemy);
        TurretHead.DOLookAt(enemy.transform.position, turretLevel);

        if (shortDis < range) Shot();
    }
    void Shot()
    {
        CurAttackSp -= Time.deltaTime;

        if (CurAttackSp <= 0)
        {
            GameObject bullet = Instantiate(BulletPrefab, ShotPos.position, ShotPos.rotation);
            CurAttackSp = AttackSp;
        }
    }
    void Dead()
    {
        if (CurHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
