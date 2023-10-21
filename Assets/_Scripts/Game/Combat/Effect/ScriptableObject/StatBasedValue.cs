using System;
using UnityEngine;

[Serializable]
public class StatBasedValue
{
    [field: SerializeField] public Stat BaseOn { get; private set; }

    [field: SerializeField] public float PercentValue { get; private set; }

    [field: SerializeField] public float FixedValue { get; private set; }
    [field: SerializeField] public bool UseCustomCriticalRate { get; private set; }
    [field: SerializeField] public float CustomCriticalRate { get; private set; }

    public float GetRawValue(CharacterStatus source)
    {
        return source.Stats[BaseOn].FinalValue * PercentValue + FixedValue;
    }
}