using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class CharacterStatus : MyMonoBehaviour
{
    [field: SerializeField] public Collider2D HitBox { get; private set; }
    public Vector2 Position => HitBox.bounds.center;

    public bool immortal;
    public bool IsImmortal => immortal;
    public bool invisibility;
    public bool IsInvisibility => Health.IsEmpty || invisibility;
    public enum Team
    {
        Hero,
        Monster
    }
    public Team team;
    public event Action<DamageBlock> OnDealDamage;
    public event Action<DamageBlock> OnTakeDamage;
    public event Action<CharacterStatus> OnDead;

    public readonly ResourceBlock Health = new();
    public readonly ResourceBlock Mana = new();
    public readonly CharacterStats Stats = new();
    protected readonly HashSet<IEffect> _effects = new();

    public bool IsDead => Health.Current <= Mathf.Epsilon;

    protected override void Awake()
    {
        base.Awake();
        Health.OnValueChange += CheckForDeath;
    }

    protected override void Reset()
    {
        base.Reset();
        if (HitBox == null)
        {
            HitBox = GetComponent<Collider2D>();
        }
    }

    public virtual void TakeDamage(DamageBlock damageBlock)
    {
        if (IsImmortal || IsInvisibility)
            return;

        damageBlock.CalculateFinalDamage(this);
        Health.Draw(damageBlock.CurrentDamage);
        damageBlock.Source.OnDealDamage?.Invoke(damageBlock);
        damageBlock.Target.OnTakeDamage?.Invoke(damageBlock);
        // DamageFeedback.Display(damageBlock);
    }

    public void ReceiveEffect(IEffect effect, CharacterStatus contributer)
    {
        effect.Instanciate(contributer, this);
        _effects.Add(effect);
    }

    public void RemoveEffect(IEffect effect)
    {
        if (_effects.Remove(effect))
        {
            effect.CleanUp();
        }
    }

    public void RemoveEffect(Func<IEffect, bool> predicate)
    {
        IEnumerable<IEffect> deletedEffects = _effects.Where(effect => predicate(effect));
        foreach (IEffect effect in deletedEffects)
        {
            RemoveEffect(effect);
        }
    }

    public void RemoveAllEffect()
    {
        foreach (IEffect effect in _effects)
        {
            effect.CleanUp();
        }
        _effects.Clear();
    }

    private void CheckForDeath(float current, float max)
    {
        if (current <= Mathf.Epsilon)
        {
            OnDead?.Invoke(this);
        }
    }
}
