using System.Collections;
using UnityEngine;

public class MonsterAnimation : CharacterAnimation
{
	WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();
	Color originalColor = Color.white;
	Color shootAttackColor = Color.red;

	Coroutine hurtAnimCoroutine;
	Coroutine deathAnimCoroutine;

	[SerializeField] AnimationClip normalAttackAnimation;

	public virtual void PlayHurtAnimation()
	{
		if (hurtAnimCoroutine != null) return;
		hurtAnimCoroutine = StartCoroutine(HurtAnimationCoroutine());
	}

	IEnumerator HurtAnimationCoroutine()
	{
		float timer = 0;
		float elapsed = 0.15f;

		while (timer <= elapsed)
		{
			timer += Time.fixedDeltaTime;
			float lerpAmount = timer / elapsed;
			spriteRenderer.color = Color.Lerp(originalColor, shootAttackColor, lerpAmount);

			yield return waitForFixedUpdate;
		}
		timer = 0;
		while (timer <= elapsed)
		{
			timer += Time.fixedDeltaTime;
			float lerpAmount = timer / elapsed;
			spriteRenderer.color = Color.Lerp(shootAttackColor, originalColor, lerpAmount);

			yield return waitForFixedUpdate;
		}

		spriteRenderer.color = originalColor;

		hurtAnimCoroutine = null;
	}

	public virtual void PlayDeathAnimation()
	{
		if (deathAnimCoroutine != null) return;
		deathAnimCoroutine = StartCoroutine(DeathAnimationCoroutine());
	}

	IEnumerator DeathAnimationCoroutine()
	{
		float timer = 0;
		float elapsed = 0.4f;

		Color updateColor = spriteRenderer.color;
		while (timer <= elapsed)
		{
			timer += Time.fixedDeltaTime;
			float lerpAmount = timer / elapsed;
			spriteRenderer.color = Color.Lerp(originalColor, shootAttackColor, lerpAmount);
			updateColor.a = Mathf.Lerp(updateColor.a, 0, lerpAmount);
			spriteRenderer.color = updateColor;

			yield return waitForFixedUpdate;
		}

		deathAnimCoroutine = null;
	}

	public virtual void PlayNormalAttackAnim()
	{
		ChangeAnimationState(AnimationManager.NormalAttackHash);
		DisableAnimationFor(normalAttackAnimation.length);
	}

	public virtual void PlayIdleAnim()
	{
		ChangeAnimationState(AnimationManager.IdleHash);
	}

	public virtual void PlayRunAnim()
	{
		ChangeAnimationState(AnimationManager.RunHash);
	}
}