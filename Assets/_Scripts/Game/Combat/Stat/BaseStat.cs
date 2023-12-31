using System;
using System.Collections.Generic;
using UnityEngine;

public enum Stat
{
    MaxHealth,
    MaxMana,

    AttackPower,
    HitRate,
    AttackRange,
    CriticalChance,
    CritticalHitDamage,

    MoveSpeed,
}

[Serializable]
public class GrowStat
{
    public float baseValue;
    public float growAmount;
    public int maxLevel;

}

public class BaseStat
{
    [SerializeField] private float _baseValue;

    public float BaseValue
    {
        get => _baseValue;
        set
        {
            if (value <= 0) value = 0;
            _baseValue = value;
            CalculateFinalValue();
        }
    }

    public event Action<float> OnValueChange;
    private readonly List<StatModifier> _bonusStats = new();

    public float FinalValue { get; private set; }

    public BaseStat()
    {
        _baseValue = 0;
    }

    public BaseStat(float baseValue)
    {
        this._baseValue = baseValue;
        CalculateFinalValue();
    }

    public void AddBonus(StatModifier bonus)
    {
        _bonusStats.Add(bonus);
        _bonusStats.Sort();
        CalculateFinalValue();
    }

    public void RemoveBonus(StatModifier stat)
    {
        _bonusStats.Remove(stat);
        CalculateFinalValue();
    }

    public void ClearAllBonus()
    {
        _bonusStats.Clear();
        CalculateFinalValue();
    }

    private void CalculateFinalValue()
    {
        float totalAddByPercent = 0;
        float sumBonus = _baseValue;
        foreach (StatModifier stat in _bonusStats)
        {
            if (stat.bonusType == StatModifier.BonusType.Flat)
            {
                sumBonus += stat.value;
            }
            else if (stat.bonusType == StatModifier.BonusType.PercentAdd)
            {
                totalAddByPercent += stat.value * sumBonus;
            }
            else
            {
                sumBonus += (sumBonus + totalAddByPercent) * (1 + stat.value);
            }
        }
        FinalValue = sumBonus + totalAddByPercent;
        if (FinalValue < 0) FinalValue = 0;
        OnValueChange?.Invoke(FinalValue);
    }
}