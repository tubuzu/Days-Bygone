using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Fence : MonoBehaviour
{
	[SerializeField] Tilemap fenceTilemap;
	Coroutine hurtAnimCoroutine;
	Color originalColor = Color.white;
	Color shootAttackColor = Color.red;
	WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();
	public virtual void PlayHurtAnimation()
	{
		if (hurtAnimCoroutine != null) return;
		Debug.Log("fence hurt");
		hurtAnimCoroutine = StartCoroutine(HurtAnimationCoroutine());
	}

	IEnumerator HurtAnimationCoroutine()
	{
		float timer = 0;
		float elapsed = 0.05f;

		while (timer <= elapsed)
		{
			timer += Time.fixedDeltaTime;
			float lerpAmount = timer / elapsed;
			fenceTilemap.color = Color.Lerp(originalColor, shootAttackColor, lerpAmount);

			yield return waitForFixedUpdate;
		}
		timer = 0;
		while (timer <= elapsed)
		{
			timer += Time.fixedDeltaTime;
			float lerpAmount = timer / elapsed;
			fenceTilemap.color = Color.Lerp(shootAttackColor, originalColor, lerpAmount);

			yield return waitForFixedUpdate;
		}

		fenceTilemap.color = originalColor;
		hurtAnimCoroutine = null;
	}
}