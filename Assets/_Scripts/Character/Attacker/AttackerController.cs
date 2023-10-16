using UnityEngine;

public class AttackerController : MyMonoBehaviour
{
    [SerializeField] protected AttackerStatus attackerStatus;
    public AttackerStatus AttackerStatus { get => attackerStatus; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.attackerStatus = transform.Find("Status").GetComponent<AttackerStatus>();
    }

}
