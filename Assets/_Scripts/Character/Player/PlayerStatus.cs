using UnityEngine;

public class PlayerStatus : CharacterStatus
{
    [SerializeField] protected PlayerStatData statsData;
    [SerializeField] protected PlayerController playerController;
    public PlayerController PlayerController { get { return playerController; } }

    protected override void OnEnable()
    {
        base.OnEnable();
        InstanciateFromStatsData();
    }

    protected override void Reset()
    {
        base.Reset();
        this.LoadPlayerController();
    }
    protected virtual void LoadPlayerController()
    {
        if (playerController != null) return;
        Transform curTransform = transform;
        while (!curTransform.TryGetComponent(out playerController)) curTransform = curTransform.parent;
    }

    public void InstanciateFromStatsData()
    {
        Stats[Stat.MaxHealth].BaseValue = statsData.MaxHealth.baseValue;
        Stats[Stat.MaxMana].BaseValue = statsData.MaxMana.baseValue;
        Stats[Stat.AttackPower].BaseValue = statsData.AttackPower.baseValue;
        Stats[Stat.HitRate].BaseValue = statsData.HitRate.baseValue;
        Stats[Stat.CriticalChance].BaseValue = statsData.CriticalChance.baseValue;
        Stats[Stat.CritticalHitDamage].BaseValue = statsData.CritticalHitDamage.baseValue;
    }

}
