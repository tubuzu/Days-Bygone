using UnityEngine;

public class DirectionalExplosionStrightSpell : StraightExplosionBullet
{
    protected override void Explosion(Vector2 position)
    {
        if (explosionPrefab != null && PoolManager.Get<IPoolObject>(explosionPrefab, out var instance))
        {
            instance.gameObject.transform.SetPositionAndRotation(position, transform.rotation);
        }
        var hits = Physics2D.OverlapCircleAll(position, explosionRange, LayerMaskHelper.FigherMask);
        foreach (var hit in hits)
        {
            if (hit.TryGetComponent<CharacterStatus>(out var fighter))
            {
                if (friendlyHit)
                {
                    ability.HitThisFighter(fighter);
                }
                else if (ability.IsRightTarget(fighter))
                {
                    ability.HitThisFighter(fighter);
                }

            }
        }
    }
}