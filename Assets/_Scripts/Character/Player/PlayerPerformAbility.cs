using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPerformAbility : PlayerAbstract
{
    [SerializeField] private ActiveRune basicAbilityRune;

    public OrientationAbility normalAttack;
    public AbilityCaster abilityCaster;
    private Camera _camera;

    protected override void OnEnable()
    {
        base.OnEnable();
        _camera = CameraManager.MainCam;
    }

    private void Update()
    {
        abilityCaster.LookDirection = _camera.ScreenToWorldPoint(Input.mousePosition);
    }

    public virtual void PerformNormalAttack()
    {
        if (normalAttack == null)
        {
            normalAttack = (OrientationAbility)basicAbilityRune.CreateItem();
            normalAttack.Install(abilityCaster);
        }
        if (normalAttack.IsReady())
        {
            normalAttack.TryUse();
        }
    }
}
