using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MyMonoBehaviour
{
    [SerializeField] protected Animator animator;
    public Animator Animator { get => animator; }
    [SerializeField] protected SpriteRenderer spriteRenderer;
    public SpriteRenderer SpriteRenderer { get => spriteRenderer; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.animator = GetComponent<Animator>();
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
