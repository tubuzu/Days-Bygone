using System;
using System.Collections.Generic;

public enum Stat
{
    MaxHealth,
    MaxMana,
    MoveSpeed,
    AttackPower,
    AttackRange,
    CriticalChance,
    CritticalHitDamage
}

[Serializable]
public class CharacterStat
{
    private readonly Dictionary<Stat, BaseStat> _stats;

    public BaseStat this[Stat stat] => _stats[stat];

    public CharacterStat()
    {
        _stats = new Dictionary<Stat, BaseStat>();
        foreach (Stat statType in Enum.GetValues(typeof(Stat)))
        {
            _stats[statType] = new BaseStat(0);
        }
    }

    public void SetStatBase(BaseStatData data)
    {
        _stats[Stat.MaxHealth].BaseValue = data.MaxHealth.baseValue;
        _stats[Stat.MaxMana].BaseValue = data.MaxMana.baseValue;
        _stats[Stat.MoveSpeed].BaseValue = data.MoveSpeed.baseValue;
        _stats[Stat.AttackPower].BaseValue = data.AttackPower.baseValue;
        _stats[Stat.AttackRange].BaseValue = data.AttackRange.baseValue;
        _stats[Stat.CriticalChance].BaseValue = data.CriticalChance.baseValue;
        _stats[Stat.CritticalHitDamage].BaseValue = data.CritticalHitDamage.baseValue;
    }

    public void ClearAllBonus()
    {
        foreach (BaseStat baseStats in _stats.Values)
        {
            baseStats.ClearAllBonus();
        }
    }

    public void ApplyModifier(Stat statsType, StatModifier statBonus)
    {
        _stats[statsType].AddBonus(statBonus);
    }

    public void RemoveModifier(Stat statsType, StatModifier statBonus)
    {
        _stats[statsType].RemoveBonus(statBonus);
    }

    public BaseStat GetStats(Stat statType)
    {
        return _stats[statType];
    }
}
