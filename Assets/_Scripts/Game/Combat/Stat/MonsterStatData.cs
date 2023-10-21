using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterBaseStats", menuName = "Data/Monster/Stats/Base")]
public class MonsterStatData : ScriptableObject
{
    public GrowStat MaxHealth;
    public GrowStat MoveSpeed;
    public GrowStat AttackPower;
    public GrowStat HitRate;
    public GrowStat AttackRange;
    public GrowStat CriticalChance;
    public GrowStat CritticalHitDamage;

}

[Serializable]
public class MonsterGrowStat
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