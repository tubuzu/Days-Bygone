using UnityEngine;
using UnityEngine.Pool;

[CreateAssetMenu(fileName = "Damage", menuName = "Effects/Instant/Damage")]
public class DamageEffect : BaseEffectAndFactory
{
    // [SerializeField] protected DamageType damageType;
    [SerializeField] protected StatBasedValue damageBased;

    public override void Instanciate(CharacterStatus source, CharacterStatus target)
    {
        float rawDamage = damageBased.GetRawValue(source);
        var damageBlock = GenericPool<DamageBlock>.Get();
        damageBlock.Init(source, rawDamage);
        target.TakeDamage(damageBlock);
        GenericPool<DamageBlock>.Release(damageBlock);
    }
}