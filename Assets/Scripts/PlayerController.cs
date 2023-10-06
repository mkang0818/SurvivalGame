using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public HeroStat herostat;

    public Animator anim;

    Slider hpBar;
    Slider expBar;

    float hAxis;
    float vAxis;
    Vector3 moveVec;

    [Header ("½ºÅÝ")]
    public float curHP;
    public float maxHP;
    public float maxEXP;
    public float curEXP;
    public float moveSp;
    void Start()
    {
        herostat.InitStat();

        hpBar = GameObject.Find("UI").transform.Find("HPSlider").GetComponent<Slider>();
        expBar = GameObject.Find("UI").transform.Find("EXPSlider").GetComponent<Slider>();

        hpBar.value = curHP / maxHP;
        expBar.value = curHP / maxHP;
    }


    void Update()
    {
        Move();
        Shot();
        UpdateHP();
        LookMouseCursor();
    }
    void Move()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");

        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += moveVec * moveSp * Time.deltaTime;
        //transform.LookAt(transform.position + moveVec);

        anim.SetBool("Run", moveVec != Vector3.zero);
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
    void Shot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("Shot");
        }
    }
    void UpdateHP()
    {
        hpBar.value = Mathf.Lerp(hpBar.value, curHP / maxHP, Time.deltaTime * 10);
    }
}
