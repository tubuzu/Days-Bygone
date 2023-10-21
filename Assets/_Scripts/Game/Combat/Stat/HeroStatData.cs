using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HeroBaseStats", menuName = "Data/Hero/Stats/Base")]
public class HeroStatData : ScriptableObject
{
    public GrowStat MaxHealth;
    public GrowStat AttackPower;
    public GrowStat AttackRange;
    public GrowStat CriticalChance;
    public GrowStat CritticalHitDamage;

}

[Serializable]
public class HeroGrowStat
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

