using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerBaseStats", menuName = "Data/Player/Stats/Base")]
public class PlayerStatData : ScriptableObject
{
    public GrowStat MaxHealth;
    public GrowStat MaxMana;
    public GrowStat AttackPower;
    public GrowStat HitRate;
    public GrowStat CriticalChance;
    public GrowStat CritticalHitDamage;

}