using UnityEngine;

public class HeroAbstract : MyMonoBehaviour
{
    [SerializeField] protected HeroController heroController;
    public HeroController HeroController { get { return heroController; } }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHeroController();
    }
    protected virtual void LoadHeroController()
    {
        if (heroController != null) return;
        Transform curTransform = transform;
        while (!curTransform.TryGetComponent(out heroController))
        {
            if (curTransform == transform.root) break;
            curTransform = curTransform.parent;
        }
    }
}