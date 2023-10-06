using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] Monster = new GameObject[10];
    public GameObject[] monsterArr;

    public int stagelevel;
    float level = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("spawnMosnter");
    }
    IEnumerator spawnMosnter()
    {
        while (true)
        {
            int randType = Random.Range(0, stagelevel+1);
            float randXPos = Random.Range(-17, 17);
            float randYPos = Random.Range(-17, 17);
            int i = 0;
            monsterArr[i] = Instantiate(Monster[randType], new Vector3(randXPos, 0, randYPos), Quaternion.identity);
            i++;
            //monster //따라가기 구현

            yield return new WaitForSeconds(level);
        }
    }
}
