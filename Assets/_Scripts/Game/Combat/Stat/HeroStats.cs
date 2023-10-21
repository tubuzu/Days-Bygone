using UnityEngine;

public class HeroStats : CharacterStats
{
	public void SetStatBase(HeroStatData data)
	{
		_stats[Stat.MaxHealth].BaseValue = data.MaxHealth.baseValue;
		_stats[Stat.AttackPower].BaseValue = data.AttackPower.baseValue;
		_stats[Stat.AttackRange].BaseValue = data.AttackRange.baseValue;
		_stats[Stat.CriticalChance].BaseValue = data.CriticalChance.baseValue;
		_stats[Stat.CritticalHitDamage].BaseValue = data.CritticalHitDamage.baseValue;
	}
}