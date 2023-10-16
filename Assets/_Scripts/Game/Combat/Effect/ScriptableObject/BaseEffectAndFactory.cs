public abstract class BaseEffectAndFactory : BaseEffectFactory, IEffect
{
    public virtual void CleanUp() { }
    public abstract void Instanciate(CharacterStatus source, CharacterStatus target);

    public override IEffect Build()
    {
        return this;
    }
}