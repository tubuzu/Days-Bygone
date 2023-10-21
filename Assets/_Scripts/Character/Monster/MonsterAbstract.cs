using UnityEngine;

public class MonsterAbstract : MyMonoBehaviour
{
    [SerializeField] protected MonsterController monsterController;
    public MonsterController MonsterController { get { return monsterController; } }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMonsterController();
    }
    protected virtual void LoadMonsterController()
    {
        if (monsterController != null) return;
        Transform curTransform = transform;
        while (!curTransform.TryGetComponent(out monsterController))
        {
            if (curTransform == transform.root) break;
            curTransform = curTransform.parent;
        }
    }
}