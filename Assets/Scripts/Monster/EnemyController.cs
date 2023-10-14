using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Enemy EmyType;
    GameObject target;

    public GameObject MoneyPrefab;
    float speed = 3;
    [HideInInspector]
    public float hp = 5f;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");


        EmyType.initSetting();
        EmyType.Attack(target);
    }

    // Update is called once per frame
    void Update()
    {
        EmyType.Dead(MoneyPrefab);
    }
    void followTarget()
    {
        transform.LookAt(target.transform);

        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Bullet"))
        {
            Destroy(col.gameObject);
            EmyType.EmyStat.EmyHP -= 5;
        }
        if (col.gameObject.CompareTag("Player"))
        {
            bool isEvasion = RandomEvasion(col.GetComponent<PlayerController>().herostat.data.lucky);

            if (isEvasion)
            {
                print("È¸ÇÇ!!");
            }
            else
            {
                col.GetComponent<PlayerController>().herostat.data.CurHp -= (int)(EmyType.EmyStat.EmyAttack - (0.5 * col.GetComponent<HeroStat>().data.defense));
            }
        }
    }
    bool RandomEvasion(float persent)
    {
        float randomValue = Random.value;
        return randomValue <= persent;
    }
}