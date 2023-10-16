using UnityEngine;

[CreateAssetMenu(fileName = "Recovery Effect", menuName = "Effects/Instant/Heal")]
public class HealEffect : BaseEffectAndFactory
{
    [SerializeField] protected StatBasedValue basedValue;

    public override void Instanciate(CharacterStatus source, CharacterStatus receiver)
    {
        float healAmount = basedValue.GetRawValue(source);
        receiver.Health.Recover(healAmount);
    }
}