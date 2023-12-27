using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLv1 : MonoBehaviour
{
    public InGameManager InGameManager;
    int Stage = 1;
    int num = 1;

    public GameObject Lv1Monster;

    public GameObject[] monsterArr = new GameObject[0];


    float level = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("spawnMosnter");
    }
    void Update()
    {
        Leveling();
    }
    void Leveling()
    {
        Stage = InGameManager.StageNum;

        //스테이지마다 줄이기
        if (num < Stage)
        {
            level *= 1.2f;
            num = Stage;
        }
    }
    IEnumerator spawnMosnter()
    {
        while (true)
        {
            float randXPos = Random.Range(-8.5f, 8.5f);
            float randZPos = Random.Range(-8.5f, 8.5f);

            GameObject monster = Instantiate(Lv1Monster, new Vector3(randXPos, 0, randZPos), Quaternion.identity);

            yield return new WaitForSeconds(level);
        }
    }
}
