using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterBehaviourState
{
    Running,
    Attacking,
    Dead,
}

public class BaseMonsterCombatBehaviour : MonsterController
{
    protected Vector2 forwardDirection = Vector2.left;
    protected Vector2 backwardDirection = Vector2.right;

    [SerializeField] private ActiveRune basicAbilityRune;
    public OrientationAbility normalAttack;
    public AbilityCaster abilityCaster;

    protected MonsterBehaviourState state;

    protected override void OnEnable()
    {
        base.OnEnable();
        CharacterMovement.Move(forwardDirection, MonsterStatus.Stats[Stat.MoveSpeed].FinalValue);
        abilityCaster.LookDirection = forwardDirection;
    }

    protected virtual void FixedUpdate()
    {
        if (monsterStatus.IsDead)
        {
            if (state != MonsterBehaviourState.Dead)
            {
                state = MonsterBehaviourState.Dead;
                monsterAnimation.PlayDeathAnimation();
            }
            return;
        }
        if (transform.position.x <= monsterStatus.Stats[Stat.AttackRange].FinalValue)
        {
            if (state != MonsterBehaviourState.Attacking)
                characterMovement.Move(Vector2.zero, 0);
            state = MonsterBehaviourState.Attacking;
            PerformNormalAttack();
        }
        else
        {
            state = MonsterBehaviourState.Running;
        }
    }

    public virtual void PerformNormalAttack()
    {
        if (normalAttack == null)
        {
            normalAttack = (OrientationAbility)basicAbilityRune.CreateItem();
            normalAttack.Install(abilityCaster);
        }
        if (normalAttack.IsReady())
        {
            normalAttack.TryUse();
            monsterAnimation.PlayNormalAttackAnim();
        }
        else monsterAnimation.PlayIdleAnim();
    }
}
