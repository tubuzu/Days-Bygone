using System.Collections.Generic;
using System.Text;
using UnityEngine.Pool;
using UnityEngine;

[CreateAssetMenu(fileName = "Passive rune", menuName = "Rune/Passive")]
public class PassiveRune : Rune
{
    [SerializeField] private List<BaseEffectFactory> effectsApplyWhenEquip;

    public IEnumerable<BaseEffectFactory> EffectsApplyWhenEquip => effectsApplyWhenEquip;

    public override IItem CreateItem()
    {
        return new PassiveAbility(this);
    }

    private readonly static string[] _types = new string[] { "Rune", "Passive" };

    public override IEnumerable<string> GetSubTypes() => _types;
}