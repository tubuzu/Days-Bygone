using UnityEngine;

public class PlayerStats : CharacterStats
{
	public void SetStatBase(PlayerStatData data)
	{
		_stats[Stat.MaxHealth].BaseValue = data.MaxHealth.baseValue;
		_stats[Stat.MaxMana].BaseValue = data.MaxMana.baseValue;
		_stats[Stat.AttackPower].BaseValue = data.AttackPower.baseValue;
		_stats[Stat.HitRate].BaseValue = data.HitRate.baseValue;
		_stats[Stat.CriticalChance].BaseValue = data.CriticalChance.baseValue;
		_stats[Stat.CritticalHitDamage].BaseValue = data.CritticalHitDamage.baseValue;
	}
}