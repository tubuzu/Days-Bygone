using UnityEngine;
using UnityEngine.UI;

public class FollowHealthBar : PoolObject
{
    [SerializeField] private Image fillImage;
    [SerializeField] private Vector2 offset;

    private Vector2 _finalOffset;
    private AttackerController _attachedAttacker;

    public void AttachToAttacker(AttackerController attacker)
    {
        DeAttached();
        _attachedAttacker = attacker;
        _finalOffset = offset + new Vector2(0, attacker.AttackerStatus.HitBox.bounds.extents.y);
        attacker.AttackerStatus.Health.OnValueChange += ChangeValueUI;
        ChangeValueUI(attacker.AttackerStatus.Health.Current, attacker.AttackerStatus.Health.Capacity);
    }

    private void OnDisable()
    {
        DeAttached();
    }

    private void LateUpdate()
    {
        if (_attachedAttacker != null)
        {
            transform.position = _attachedAttacker.AttackerStatus.Position + _finalOffset;
        }
    }

    private void ChangeValueUI(float current, float max)
    {
        fillImage.fillAmount = current / max;
    }

    private void DeAttached()
    {
        if (_attachedAttacker != null)
        {
            _attachedAttacker.AttackerStatus.Health.OnValueChange -= ChangeValueUI;
        }
        _attachedAttacker = null;
    }
}
