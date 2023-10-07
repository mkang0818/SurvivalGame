using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    [Header ("½ºÅÝ")]
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
        //Dodge();
        Shot();
        UpdateHP();
        LookMouseCursor();
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
    void Dodge()
    {
        if (moveVec!=Vector3.zero && isDodge)
        {
            moveSp *= 3;

            if (transform.rotation.eulerAngles.y >= 315)
            {
                if (hAxis > 0 && vAxis > 0)
                {
                    anim.SetTrigger("BackDodge");
                }
            }
            //anim.SetTrigger("isDodge");

            Invoke("DodgeOut",0.5f);
        }
    }
    void DodgeOut()
    {
        moveSp /= 3;
    }
    public void LookMouseCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitResult;
        if (Physics.Raycast(ray, out hitResult))
        {
            Vector3 mouseDir = new Vector3(hitResult.point.x, transform.position.y, hitResult.point.z) - transform.position;
            transform.forward = mouseDir;
        }
    }
    void Dead()
    {
        if (curHP <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
    void Shot()
    {
        AttackcoolTime -= Time.deltaTime;
        if (AttackcoolTime <= 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                anim.SetTrigger("Shot");
                AttackcoolTime = AttackSp;
            }
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
