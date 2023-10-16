using UnityEngine;

[CreateAssetMenu(fileName = "Effects", menuName = "Effects/Duration/Over time/Recorvery")]
public class HealOverTimeEffectFactory : BaseEffectFactory
{
    [SerializeField] protected StatBasedValue basedValue;

    [Tooltip("Time elapses between each tick of heal")]
    [SerializeField] protected float healInterval;

    public override IEffect Build()
    {
        return new HealOverTimeEffect(this);
    }

    public class HealOverTimeEffect : IEffect
    {
        private HealOverTimeEffectFactory _effectFactory;

        public HealOverTimeEffect(HealOverTimeEffectFactory effectFactory)
        {
            _effectFactory = effectFactory;
        }

        public EffectInfo EffectInfo => _effectFactory.EffectInfo;

        public void Instanciate(CharacterStatus source, CharacterStatus target)
        {
            // Do heal coroutine
        }

        public void CleanUp()
        {

        }


    }
}