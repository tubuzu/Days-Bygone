using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GrowStat
{
    public float baseValue;
    public float growAmount;
    public int maxLevel;

}

[CreateAssetMenu(fileName = "BaseStats", menuName = "Data/Stats/Base")]
public class BaseStatData : ScriptableObject
{
    public GrowStat MaxHealth;
    public GrowStat MaxMana;
    public GrowStat MoveSpeed;
    public GrowStat AttackPower;
    public GrowStat AttackRange;
    public GrowStat CriticalChance;
    public GrowStat CritticalHitDamage;

}

[Serializable]
public class AttackerGrowStat
{
    public float Health;
    public float AttackPower;

    public Dictionary<Stat, StatModifier> GetGrowingStat(int day)
    {
        var modifiers = new Dictionary<Stat, StatModifier>();

        if (Health > 0)
        {
            modifiers.Add(Stat.MaxHealth, new StatModifier(Health * day, StatModifier.BonusType.Flat, 0));
        }
        if (AttackPower > 0)
        {
            modifiers.Add(Stat.AttackPower, new StatModifier(AttackPower * day, StatModifier.BonusType.Flat, 0));
        }
        return modifiers;
    }
}

[Serializable]
public class DefenderGrowStat
{
    public float AttackPower;

    public Dictionary<Stat, StatModifier> GetGrowingStat(int level)
    {
        var modifiers = new Dictionary<Stat, StatModifier>();

        if (AttackPower > 0)
        {
            modifiers.Add(Stat.AttackPower, new StatModifier(AttackPower * level, StatModifier.BonusType.Flat, 0));
        }
        return modifiers;
    }
}