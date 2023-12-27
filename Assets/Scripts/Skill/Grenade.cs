using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public GameObject meshObj;
    public GameObject effectObj;
    public Rigidbody rigid;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Explosion());
    }
    IEnumerator Explosion()
    {
        yield return new WaitForSeconds(3f);
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;

        RaycastHit[] rayHits = Physics.SphereCastAll(transform.position, 
            15, Vector3.up, 0, LayerMask.GetMask("Enemy"));
        foreach (RaycastHit hitObj in rayHits)
        {
            hitObj.transform.GetComponent<EnemyController>().Emy.EmyStat.EmyHP -= 100;
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.transform.CompareTag("Ground") || col.transform.CompareTag("Enemy"))
        {
            print("Æã!");
            Destroy(gameObject);
        }
    }
}
