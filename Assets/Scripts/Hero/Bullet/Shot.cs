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

        Destroy(bullet, 0.3f);
    }
    public void CowBoyShotEvent()
    {
        GameObject bullet = Instantiate(BulletPrefab, ShotPos.transform.position, ShotPos.transform.rotation);
        GameObject bullet1 = Instantiate(BulletPrefab, ShotPos.transform.position, ShotPos.transform.rotation * Quaternion.Euler(0, -15, 0));
        GameObject bullet2 = Instantiate(BulletPrefab, ShotPos.transform.position, ShotPos.transform.rotation * Quaternion.Euler(0, 15, 0));

        Destroy(bullet, 0.3f);
        Destroy(bullet1, 0.3f);
        Destroy(bullet2, 0.3f);
    }
}
