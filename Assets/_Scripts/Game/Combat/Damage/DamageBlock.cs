using System;

public enum DamageState
{
    NormalDamage,
    CriticalDamage,
}

public class DamageBlock
{
    #region Static Member
    private const float BLOCKMULTILIER = -0.7f;
    private static readonly Action<DamageBlock>[] _actionMap = new Action<DamageBlock>[] {
        CriticalCalculater,
    };

    private static void CriticalCalculater(DamageBlock damageBlock)
    {
        if (!Chance.TryOnPercent(damageBlock.Source.Stats[Stat.CriticalChance].FinalValue))
            return;
        damageBlock.AddMutiplier(damageBlock.Source.Stats[Stat.CritticalHitDamage].FinalValue / 100);
        damageBlock.State = DamageState.CriticalDamage;
    }
    #endregion

    public float RawDamage { get; private set; }
    public DamageState State { get; private set; }
    public CharacterStatus Source { get; private set; }

    public CharacterStatus Target { get; private set; }
    public float CurrentDamage { get; private set; }
    public float Multiplier { get; private set; }

    public void Init(CharacterStatus source, float damage)
    {
        State = DamageState.NormalDamage;
        RawDamage = damage;
        Source = source;
        Multiplier = 1f;
        CurrentDamage = damage;
    }

    public void Init(float damage)
    {
        RawDamage = damage;
        Multiplier = 1f;
        CurrentDamage = damage;
    }

    public void AddMutiplier(float value)
    {
        Multiplier += value;
        CurrentDamage = RawDamage * Multiplier;
        State = DamageState.NormalDamage;
        if (CurrentDamage < 0) CurrentDamage = 0;
    }

    public void CalculateFinalDamage(CharacterStatus target)
    {
        if (RawDamage <= 0 || target == null)
            return;

        Target = target;
        foreach (var damageCalculator in _actionMap)
        {
            damageCalculator.Invoke(this);
        }
    }
}