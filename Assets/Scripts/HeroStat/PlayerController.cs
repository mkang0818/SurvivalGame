using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    //public HeroStat herostat;
    GameObject InGameManager;

    public Animator anim;

    Slider hpBar;
    Slider expBar;

    float hAxis;
    float vAxis;

    bool isDodge;
    Vector3 moveVec;

    public List<GameObject> FoundObjects;
    public GameObject enemy;
    public float shortDis;
    [Header("스텟")]
    public float curHP;
    public float maxHP;
    public float maxEXP;
    public float curEXP;
    public float moveSp;
    public float AttackSp;
    public float AttackcoolTime;
    void Start()
    {
        //herostat.InitStat();
        InGameManager = GameObject.Find("InGameManager");
        hpBar = GameObject.Find("UI").transform.Find("HPSlider").GetComponent<Slider>();
        expBar = GameObject.Find("UI").transform.Find("EXPSlider").GetComponent<Slider>();

        hpBar.value = curHP / maxHP;
        expBar.value = curHP / maxHP;
    }


    void Update()
    {
        Move();
        FindEmy();
        UpdateHP();
        Dead();
    }
    void Move()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        isDodge = Input.GetButtonDown("Dodge");

        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += moveVec * moveSp * Time.deltaTime;

        anim.SetBool("Run", moveVec != Vector3.zero);
    }
    void Dead()
    {
        if (curHP <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
    void FindEmy()
    {
        FoundObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));

        if (FoundObjects.Count == 0)
        {
            // 처리할 내용 (예: 적이 없는 경우 처리)
            return;
        }
        else Shot();

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
        gameObject.transform.DOLookAt(enemy.transform.position, 0.5f);
    }
    void Shot()
    {
        AttackcoolTime -= Time.deltaTime;
        if (AttackcoolTime <= 0)
        {
            anim.SetTrigger("Shot");

            anim.SetTrigger("Reload");
            AttackcoolTime = AttackSp;
        }
    }
    void UpdateHP()
    {
        hpBar.value = Mathf.Lerp(hpBar.value, curHP / maxHP, Time.deltaTime * 10);
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Money"))
        {
            Destroy(col.gameObject);
            InGameManager.GetComponent<InGameManager>().money += 1;
        }
    }
}
