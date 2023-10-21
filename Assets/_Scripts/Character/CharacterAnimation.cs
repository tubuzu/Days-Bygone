using System.Collections;
using UnityEngine;

public class AnimationManager : GlobalReference<AnimationManager>
{
	public static readonly int IdleHash = Animator.StringToHash("Idle");
	public static readonly int RunHash = Animator.StringToHash("Run");
	public static readonly int HurtHash = Animator.StringToHash("Hurt");
	public static readonly int DeathHash = Animator.StringToHash("Death");
	public static readonly int NormalAttackHash = Animator.StringToHash("NormalAttack");

}

public class CharacterAnimation : MyMonoBehaviour
{
	[SerializeField] protected Animator animator;
	public Animator Animator { get => animator; }
	[SerializeField] protected SpriteRenderer spriteRenderer;
	public SpriteRenderer SpriteRenderer { get => spriteRenderer; }

	protected int currentState;
	protected bool canChangeAnim = true;
	public bool CanChangeAnim { get => canChangeAnim; set => canChangeAnim = value; }

	protected Coroutine disableAnimationCoroutine;

	protected override void LoadComponents()
	{
		base.LoadComponents();
		this.animator = GetComponent<Animator>();
		this.spriteRenderer = GetComponent<SpriteRenderer>();
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		spriteRenderer.color = Color.white;
		canChangeAnim = true;
	}

	public virtual void ChangeAnimationState(int newState)
	{
		if (currentState == newState || !canChangeAnim) return;

		animator.Play(newState, -1, 0);

		currentState = newState;
	}

	public virtual void DisableAnimationFor(float time)
	{
		if (disableAnimationCoroutine != null) return;
		disableAnimationCoroutine = StartCoroutine(DisableAnimationCoroutine(time));
	}

	IEnumerator DisableAnimationCoroutine(float time)
	{
		canChangeAnim = false;
		yield return new WaitForSeconds(time);
		canChangeAnim = true;
		disableAnimationCoroutine = null;
	}

	public void ClearState()
    {
        Animator.Rebind();
    }
}