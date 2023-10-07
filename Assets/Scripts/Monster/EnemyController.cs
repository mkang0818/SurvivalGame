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
    void Dead()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
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
            col.GetComponent<PlayerController>().curHP -= EmyType.EmyStat.EmyAttack;
            print("Ãæµ¹");
        }
    }
}