using UnityEngine;

public class MonsterStatus : CharacterStatus
{
    [SerializeField] protected MonsterStatData statsData;
    [SerializeField] protected MonsterController monsterController;
    public MonsterController MonsterController { get { return monsterController; } }

    protected override void Reset()
    {
        base.Reset();
        this.LoadPlayerController();
    }
    protected virtual void LoadPlayerController()
    {
        if (monsterController != null) return;
        Transform curTransform = transform;
        while (!curTransform.TryGetComponent(out monsterController)) curTransform = curTransform.parent;
    }

    public void InstanciateFromStatsData()
    {
        Stats[Stat.MaxHealth].OnValueChange += (value) => Health.Capacity = value;
        Stats[Stat.MoveSpeed].OnValueChange += (value) => monsterController.CharacterMovement.MoveSpeed = value;

        Stats[Stat.MaxHealth].BaseValue = statsData.MaxHealth.baseValue;
        Stats[Stat.MoveSpeed].BaseValue = statsData.MoveSpeed.baseValue;
        Stats[Stat.AttackPower].BaseValue = statsData.AttackPower.baseValue;
        Stats[Stat.HitRate].BaseValue = statsData.HitRate.baseValue;
        Stats[Stat.AttackRange].BaseValue = statsData.AttackRange.baseValue;
        Stats[Stat.CriticalChance].BaseValue = statsData.CriticalChance.baseValue;
        Stats[Stat.CritticalHitDamage].BaseValue = statsData.CritticalHitDamage.baseValue;

        Health.Fill();
    }
}
