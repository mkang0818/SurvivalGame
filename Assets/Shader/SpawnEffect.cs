using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEffect : MonoBehaviour
{
    [Header("Body")]
    [SerializeField] private Renderer _Body_renderer;
    [SerializeField] private Material Body_mtrlOrg;
    [SerializeField] private Material Body_mtrlDissolve;
    [SerializeField] private Material Body_mtrlPhase;

    [Header("Weapon")]
    [SerializeField] private Renderer _Weapon_renderer;
    [SerializeField] private Material Weapon_mtrlOrg;
    [SerializeField] private Material Weapon_mtrlDissolve;
    [SerializeField] private Material Weapon_mtrlPhase;

    [Header("Head")]
    [SerializeField] private Renderer _Head_renderer;
    [SerializeField] private Material Head_mtrlOrg;
    [SerializeField] private Material Head_mtrlDissolve;
    [SerializeField] private Material Head_mtrlPhase;



    [SerializeField] private float BodyfadeTime = 2f;
    [SerializeField] private float WeaponfadeTime = 1f;
    [SerializeField] private float HeadfadeTime = 2f;


    // Start is called before the first frame update
    void Start()
    {
        _Body_renderer.material = Body_mtrlPhase;
        _Weapon_renderer.material = Weapon_mtrlPhase;
        BodyDofade(0, 2, BodyfadeTime);
        WeaponDofade(0, 2, WeaponfadeTime);

        _Head_renderer.material = Head_mtrlPhase;
        HeadDofade(0, 2, HeadfadeTime);
    }
    //BodyFade
    void BodyDofade(float start, float dest, float time)
    {
        iTween.ValueTo(gameObject, iTween.Hash(
            "from", start, "to", dest, "time", time, "onupdatetarget", gameObject,
            "onupdate", "BodyTweenOnUpdate", "oncomplte", "BodyTweenOnComplte",
            "easetype", iTween.EaseType.easeInOutCubic));
    }
    void BodyTweenOnUpdate(float value)
    {
        _Body_renderer.material.SetFloat("_Split_Value", value);
    }
    void BodyTweenOnComplte()
    {
        _Body_renderer.material = Body_mtrlOrg;
    }

    //WeaponFade
    void WeaponDofade(float start, float dest, float time)
    {
        iTween.ValueTo(gameObject, iTween.Hash(
            "from", start, "to", dest, "time", time, "onupdatetarget", gameObject,
            "onupdate", "WeaponTweenOnUpdate", "oncomplte", "WeaponTweenOnComplte",
            "easetype", iTween.EaseType.easeInOutCubic));
    }
    void WeaponTweenOnUpdate(float value)
    {
        _Weapon_renderer.material.SetFloat("_Split_Value", value);
    }
    void WeaponTweenOnComplte()
    {
        _Weapon_renderer.material = Body_mtrlOrg;
    }

    //HeadFade
    void HeadDofade(float start, float dest, float time)
    {
        iTween.ValueTo(gameObject, iTween.Hash(
            "from", start, "to", dest, "time", time, "onupdatetarget", gameObject,
            "onupdate", "HeadTweenOnUpdate", "oncomplte", "HeadTweenOnComplte",
            "easetype", iTween.EaseType.easeInOutCubic));
    }
    void HeadTweenOnUpdate(float value)
    {
        _Head_renderer.material.SetFloat("_Split_Value", value);
    }
    void HeadTweenOnComplte()
    {
        _Head_renderer.material = Head_mtrlOrg;
    }
}
