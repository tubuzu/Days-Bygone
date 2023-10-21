using System;
using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MyMonoBehaviour
{
	[SerializeField] protected Rigidbody2D rigidbody2d;
	[SerializeField] private Transform characterTransform;

	// private static readonly Quaternion leftRotation = Quaternion.Euler(0, 180, 0);
	// private static readonly Quaternion rightRotation = Quaternion.Euler(0, 0, 0);

	public event Action OnStartMoving;
	public event Action OnStopMoving;

	[Min(0)]
	[SerializeField] protected float moveSpeed;
	public float MoveSpeed
	{
		get => moveSpeed;
		set
		{
			if (moveSpeed == value) return;
			moveSpeed = Mathf.Max(0, value);
			afterVelocity = moveSpeed * moveDirection;
			CheckForMovingEvent();
		}
	}

	[SerializeField] protected float accelerationTime = .1f;
	[SerializeField] protected float decelerationTime = .1f;

	protected Vector2 moveDirection;
	public Vector2 MoveDirection
	{
		get => moveDirection;
		set
		{
			value = value.normalized;
			if (value == moveDirection) return;
			moveDirection = value;
			elapsedTime = 0f;
			preVelocity = rigidbody2d.velocity;
			afterVelocity = moveDirection * moveSpeed;
			// if (value.x != 0)
			// {
			// 	IsFacingRight = value.x > 0;
			//  rotateTransform.rotation = IsFacingRight ? rightRotation : leftRotation;
			// }
			CheckForMovingEvent();
		}
	}

	protected int blockElement;
	public bool BlockMovement
	{
		get => blockElement > 0;
		set
		{
			if (value)
			{
				blockElement++;
			}
			else if (blockElement > 0)
			{
				blockElement--;
			}
			CheckForMovingEvent();
		}
	}

	public bool IsMoving { get; private set; }

	// public bool IsFacingRight { get; private set; }

	protected float elapsedTime = 0f;
	protected Vector2 preVelocity;
	protected Vector2 afterVelocity;

	protected override void OnEnable()
	{
		base.OnEnable();
		CheckForMovingEvent();
	}

	private void FixedUpdate()
	{
		if (elapsedTime <= accelerationTime)
		{
			rigidbody2d.velocity = Vector2.Lerp(preVelocity, afterVelocity, elapsedTime / accelerationTime);
			elapsedTime += Time.deltaTime;
		}
		else rigidbody2d.velocity = afterVelocity;
	}

	public void ClearState()
	{
		blockElement = 0;
		moveDirection = Vector2.zero;
		StopAllCoroutines();
		CheckForMovingEvent();
	}

	public void Block(float blockTime)
	{
		StartCoroutine(BlockMovementCoroutine(blockTime));
	}

	public virtual void Move(Vector2 direction, float moveSpeed)
	{
		bool change = false;
		direction = direction.normalized;
		if (this.moveSpeed != moveSpeed)
		{
			this.moveSpeed = Mathf.Max(0, moveSpeed);
			change = true;
		}
		if (direction != moveDirection)
		{
			moveDirection = direction;
			change = true;
		}
		if (change)
		{
			elapsedTime = 0f;
			preVelocity = rigidbody2d.velocity;
			afterVelocity = moveDirection * moveSpeed;
			CheckForMovingEvent();
		}
	}

	public virtual void Stop()
	{
		Move(Vector2.zero, 0f);
	}

	private bool CheckForMoving()
	{
		return !BlockMovement && MoveSpeed > Mathf.Epsilon && !MoveDirection.Equals(Vector2.zero);
	}

	private void CheckForMovingEvent()
	{
		var isMoving = CheckForMoving();

		if (IsMoving == isMoving)
			return;

		IsMoving = isMoving;
		if (isMoving)
		{
			OnStartMoving?.Invoke();
		}
		else
		{
			Stop();
			OnStopMoving?.Invoke();
		}
	}

	private IEnumerator BlockMovementCoroutine(float blockTime)
	{
		BlockMovement = true;
		yield return blockTime.Wait();
		BlockMovement = false;
	}

}