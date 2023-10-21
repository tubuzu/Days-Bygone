using UnityEngine;

public class MonsterStats : CharacterStats
{
	public void SetStatBase(MonsterStatData data)
	{
		_stats[Stat.MaxHealth].BaseValue = data.MaxHealth.baseValue;
		_stats[Stat.MoveSpeed].BaseValue = data.MoveSpeed.baseValue;
		_stats[Stat.AttackPower].BaseValue = data.AttackPower.baseValue;
		_stats[Stat.HitRate].BaseValue = data.HitRate.baseValue;
		_stats[Stat.AttackRange].BaseValue = data.AttackRange.baseValue;
		_stats[Stat.CriticalChance].BaseValue = data.CriticalChance.baseValue;
		_stats[Stat.CritticalHitDamage].BaseValue = data.CritticalHitDamage.baseValue;
	}
}