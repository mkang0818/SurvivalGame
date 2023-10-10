using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public HeroStat herostat;
    GameObject InGameManager;


    Slider hpBar;
    Slider expBar;

    public Animator anim;
    void Start()
    {
        herostat.InitStat();

        InGameManager = GameObject.Find("InGameManager");
        hpBar = GameObject.Find("UI").transform.Find("HPSlider").GetComponent<Slider>();
        expBar = GameObject.Find("UI").transform.Find("EXPSlider").GetComponent<Slider>();

        hpBar.value = herostat.data.CurHp / herostat.data.MaxHp;
        expBar.value = herostat.data.CurHp / herostat.data.MaxHp;
    }


    void Update()
    {
        herostat.Move(this.gameObject, anim);
        herostat.Dead();
        herostat.FindEmy(anim);

        UpdateHP();
    }
    void UpdateHP()
    {
        hpBar.value = Mathf.Lerp(hpBar.value, herostat.data.CurHp / herostat.data.MaxHp, Time.deltaTime * 10);
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
