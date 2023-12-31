using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

[CreateAssetMenu(fileName = "Damage", menuName = "Effects/Duration/Over time/Damage")]
public class DamageOverTimeEffectFactory : BaseEffectFactory
{
    // [SerializeField] protected DamageType damageType;
    [SerializeField] protected StatBasedValue basedValue;

    [SerializeField] protected float duration;
    [Tooltip("Time elapses between each tick of damage")]
    [SerializeField] protected float damageInterval;

    public override IEffect Build()
    {
        return new DamageOverTimeEffect(this);
    }

    public class DamageOverTimeEffect : IEffect
    {
        protected readonly DamageOverTimeEffectFactory _effectFactory;
        protected Coroutine damageRoutine;
        protected CharacterStatus target;

        public DamageOverTimeEffect(DamageOverTimeEffectFactory effectFactory)
        {
            _effectFactory = effectFactory;
        }

        public EffectInfo EffectInfo => _effectFactory.EffectInfo;

        public void Instanciate(CharacterStatus source, CharacterStatus target)
        {
            this.target = target;
            damageRoutine = target.StartCoroutine(DamageCoroutine(source, target));
        }

        private IEnumerator DamageCoroutine(CharacterStatus source, CharacterStatus target)
        {
            float rawDamage = _effectFactory.basedValue.GetRawValue(source);
            rawDamage *= _effectFactory.damageInterval;

            float endTime = Time.time + _effectFactory.duration;
            var wait = new WaitForSeconds(_effectFactory.damageInterval);
            while (Time.time < endTime)
            {
                yield return wait;
                var damageBlock = GenericPool<DamageBlock>.Get();
                damageBlock.Init(source, rawDamage);
                target.TakeDamage(damageBlock);
                GenericPool<DamageBlock>.Release(damageBlock);
            }
            target.RemoveEffect(this);
        }

        public void CleanUp()
        {
            if (damageRoutine != null)
            {
                target.StopCoroutine(damageRoutine);
            }
        }
    }
}