using UnityEngine;
using UnityEngine.UI;

public class FollowHealthBar : PoolObject
{
    [SerializeField] private Image fillImage;
    [SerializeField] private Vector2 offset;

    private Vector2 _finalOffset;
    private CharacterStatus _attachedCharacter;

    public void AttachToAttacker(CharacterStatus characterStatus)
    {
        DeAttached();
        _attachedCharacter = characterStatus;
        _finalOffset = offset + new Vector2(0, characterStatus.HitBox.bounds.extents.y);
        characterStatus.Health.OnValueChange += ChangeValueUI;
        ChangeValueUI(characterStatus.Health.Current, characterStatus.Health.Capacity);
    }

    private void OnDisable()
    {
        DeAttached();
    }

    private void LateUpdate()
    {
        if (_attachedCharacter != null)
        {
            transform.position = _attachedCharacter.Position + _finalOffset;
        }
    }

    private void ChangeValueUI(float current, float max)
    {
        fillImage.fillAmount = current / max;
    }

    private void DeAttached()
    {
        if (_attachedCharacter != null)
        {
            _attachedCharacter.Health.OnValueChange -= ChangeValueUI;
        }
        _attachedCharacter = null;
    }
}
