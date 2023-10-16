public interface IEffect
{
    EffectInfo EffectInfo { get; }
    void Instanciate(CharacterStatus source, CharacterStatus target);
    void CleanUp();
}