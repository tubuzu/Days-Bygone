using UnityEngine;

public class MonsterWorldSpaceUIManager : GlobalReference<MonsterWorldSpaceUIManager>
{
    [SerializeField] private Prefab healthBarPrefab;
    // [SerializeField] private Prefab followMonsterInfo;
    [SerializeField] private Transform worldSpaceCanvas;

    public FollowHealthBar ReceiveHealthBar(AttackerController attacker)
    {
        if(PoolManager.Get<FollowHealthBar>(healthBarPrefab, out var healthBar))
        {
            healthBar.transform.SetParent(worldSpaceCanvas);
            healthBar.AttachToAttacker(attacker);
        }
        return healthBar;
    }

    // public FollowMonsterInfo GetMonsterInfo(MonstersController monstersController)
    // {
    //     if(PoolManager.Get<FollowMonsterInfo>(followMonsterInfo, out var monsterInfo))
    //     {
    //         monsterInfo.transform.SetParent(worldSpaceCanvas);
    //         monsterInfo.AttachToMonster(monstersController);
    //     }
    //     return monsterInfo;
    // }
}