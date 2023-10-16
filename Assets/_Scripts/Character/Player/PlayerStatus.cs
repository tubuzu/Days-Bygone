using UnityEngine;

public class PlayerStatus : CharacterStatus
{
    [SerializeField] protected PlayerController playerController;
    public PlayerController PlayerController { get { return playerController; } }
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

    [SerializeField] private BaseStatData statsData;

}
