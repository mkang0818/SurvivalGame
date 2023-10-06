using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject target;

    float speed = 3;
    [HideInInspector]
    public float hp = 5f;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        followTarget();
        Dead();
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
            print(111);

            Destroy(col.gameObject);
            hp -= 5;
        }
    }
}
