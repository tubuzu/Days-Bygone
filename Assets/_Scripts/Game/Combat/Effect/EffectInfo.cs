using UnityEngine;

[System.Serializable]
public class EffectInfo
{
    public enum EffectType
    {
        Damage,
        Freeze,
        Slow,
        Knockback,
        EnemyHealthPercentDamage,
        DamageOvertime,
    }

    private static string TypeToString(EffectType type)
        => type switch
        {
            EffectType.Damage => "Damage",
            EffectType.Freeze => "Freeze",
            EffectType.Slow => "Slow",
            EffectType.Knockback => "Knockback",
            EffectType.EnemyHealthPercentDamage => "Enemy Health Percent Damage",
            EffectType.DamageOvertime => "Damage Overtime",
            _ => type.ToString()
        };

    [field: SerializeField] public EffectType EffectTypeSelect { get; private set; }

    [field: TextArea]
    [field: Tooltip("Decript effect info. Write the value it apply if needed")]
    [field: SerializeField] public string Description { get; private set; }

    [SerializeField] private Color _descriptionColor;

    public string DesriptionWithColor => Description.RichText(_descriptionColor);
    public string EffectTypeInfo => TypeToString(EffectTypeSelect);
}
