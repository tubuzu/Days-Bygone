﻿using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "BuffDeBuff", menuName = "Effects/Duration/BuffDeBuff")]
public class DurationBuffEffectFactory : BuffEffectFactory
{
    [SerializeField] private float _duration;

    public override IEffect Build()
    {
        return new DurationBuffEffect(this, _duration);
    }

    public class DurationBuffEffect : BuffEffect
    {
        private readonly float _duration;
        private Coroutine _countdownRoutine;
        private CharacterStatus _target;
        public DurationBuffEffect(BuffEffectFactory effectFactory, float duration) : base(effectFactory)
        {
            _duration = duration;
        }

        public override void Instanciate(CharacterStatus source, CharacterStatus target)
        {
            base.Instanciate(source, target);
            _target = target;
            _countdownRoutine = target.StartCoroutine(CountDownRoutine(target));
        }

        public override void CleanUp()
        {
            base.CleanUp();
            if (_countdownRoutine != null)
            {
                _target.StopCoroutine(_countdownRoutine);
            }
        }

        private IEnumerator CountDownRoutine(CharacterStatus target)
        {
            yield return new WaitForSeconds(_duration);
            if (target != null)
            {
                target.RemoveEffect(this);
            }
        }
    }
}