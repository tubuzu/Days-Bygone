using UnityEngine;

public interface ISpell : IPoolObject
{
    void KickOff(OrientationAbility ability, Vector2 direction);
}
