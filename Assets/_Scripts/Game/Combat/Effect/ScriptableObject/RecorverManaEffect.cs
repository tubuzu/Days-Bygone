using UnityEngine;

[CreateAssetMenu(fileName = "Recovery Effect", menuName = "Effects/Instant/RecorverMana")]
public class RecorverManaEffect : BaseEffectAndFactory
{
    [SerializeField] protected StatBasedValue basedValue;

    public override void Instanciate(CharacterStatus source, CharacterStatus receiver)
    {
        float healAmount = basedValue.GetRawValue(source);
        receiver.Mana.Recover(healAmount);
    }
}