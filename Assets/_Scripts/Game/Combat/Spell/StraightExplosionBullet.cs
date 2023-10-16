using UnityEngine;

public class StraightExplosionBullet : StraightBullet
{
    [SerializeField] protected Prefab explosionPrefab;
    [SerializeField] protected float explosionRange;
    [SerializeField] protected bool friendlyHit;

    protected override void OnHitTarget(CharacterStatus fighter)
    {
        Explosion(transform.position);
        ReturnToPool();
    }

    protected virtual void Explosion(Vector2 position)
    {
        if (PoolManager.Get<IPoolObject>(explosionPrefab, out var instance))
        {
            instance.gameObject.transform.position = position;
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
#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, explosionRange);
    }
#endif
}