using System;
using UnityEngine;

public class MonsterController : MyMonoBehaviour, IPoolObject
{
    [SerializeField] protected MonsterStatus monsterStatus;
    public MonsterStatus MonsterStatus { get => monsterStatus; }
    [SerializeField] protected MonsterAnimation monsterAnimation;
    public MonsterAnimation MonsterAnimation { get => monsterAnimation; }
    [SerializeField] protected CharacterMovement characterMovement;
    public CharacterMovement CharacterMovement { get => characterMovement; }

    protected override void Awake()
    {
        base.Awake();
        CharacterMovement.OnStartMoving += StartMoving;
        CharacterMovement.OnStopMoving += StopMoving;
        MonsterStatus.OnTakeDamage += OnTakeDamage;
        MonsterStatus.OnDead += OnDead;

        MonsterStatus.InstanciateFromStatsData();
    }

    protected virtual void OnDestroy()
    {
        if(CharacterMovement != null)
        {
            CharacterMovement.OnStartMoving -= StartMoving;
            CharacterMovement.OnStopMoving -= StopMoving;
        }
        if(MonsterStatus != null)
        {
            MonsterStatus.OnTakeDamage -= OnTakeDamage;
            MonsterStatus.OnDead -= OnDead;
        }
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.monsterStatus = transform.Find("Status").GetComponent<MonsterStatus>();
        this.monsterAnimation = transform.Find("Model").GetComponent<MonsterAnimation>();
        this.characterMovement = transform.Find("Movement").GetComponent<CharacterMovement>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        characterMovement.ClearState();
    }

    protected virtual void StartMoving()
    {
        monsterAnimation.ChangeAnimationState(AnimationManager.RunHash);
    }

    protected virtual void StopMoving()
    {
        monsterAnimation.ChangeAnimationState(AnimationManager.IdleHash);
    }

    protected virtual void OnTakeDamage(DamageBlock block)
    {
        Debug.Log("take damage");
        monsterAnimation.PlayHurtAnimation();
    }

    protected virtual void OnDead(CharacterStatus _)
    {
        monsterAnimation.PlayDeathAnimation();
        characterMovement.BlockMovement = true;
    }


    #region Pooling
    private Action<IPoolObject> _returnAction;

    public void Init(Action<IPoolObject> returnAction)
    {
        _returnAction = returnAction;
    }

    public void ReturnToPool()
    {
        if (_returnAction != null)
        {
            _returnAction.Invoke(this);
            _returnAction = null;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion
}
