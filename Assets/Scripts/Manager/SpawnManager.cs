using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject IngameManager;
    public GameObject[] Monster = new GameObject[10];
    
    public GameObject[] monsterArr = new GameObject[0];
    

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
            int randType = Random.Range(0, IngameManager.GetComponent<InGameManager>().StageNum);
            float randXPos = Random.Range(-17, 17);
            float randYPos = Random.Range(-17, 17);

            GameObject monster = Instantiate(Monster[randType], new Vector3(randXPos, 0, randYPos), Quaternion.identity);

            yield return new WaitForSeconds(level);
        }
    }
}
