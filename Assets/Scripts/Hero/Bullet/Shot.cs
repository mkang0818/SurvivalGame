using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public Transform ShotPos;
    public GameObject BulletPrefab;

    
    public void ShotEvent()
    {
        GameObject bullet = Instantiate(BulletPrefab, ShotPos.transform.position, ShotPos.transform.rotation);

        Destroy(bullet, 0.1f);
    }

}
