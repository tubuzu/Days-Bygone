using UnityEngine;

public class PlayerAbstract : MyMonoBehaviour
{
    [SerializeField] protected PlayerController playerController;
    public PlayerController PlayerController { get { return playerController; } }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerController();
    }
    protected virtual void LoadPlayerController()
    {
        if (playerController != null) return;
        Transform curTransform = transform;
        while (!curTransform.TryGetComponent(out playerController))
        {
            if (curTransform == transform.root) break;
            curTransform = curTransform.parent;
        }
    }
}
