using System;
using System.Collections.Generic;

[Serializable]
public class CharacterStats
{
    protected readonly Dictionary<Stat, BaseStat> _stats;

    public BaseStat this[Stat stat] => _stats[stat];

    public CharacterStats()
    {
        _stats = new Dictionary<Stat, BaseStat>();
        foreach (Stat statType in Enum.GetValues(typeof(Stat)))
        {
            _stats[statType] = new BaseStat(0);
        }
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
