using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MyMonoBehaviour
{
    [SerializeField] protected HeroStatus heroStatus;
    public HeroStatus HeroStatus { get => heroStatus; }
    [SerializeField] protected CharacterAnimation HeroAnimation;
    public CharacterAnimation CharacterAnimation { get => HeroAnimation; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.heroStatus = transform.Find("Status").GetComponent<HeroStatus>();
        this.HeroAnimation = transform.Find("Model").GetComponent<CharacterAnimation>();
    }

}
