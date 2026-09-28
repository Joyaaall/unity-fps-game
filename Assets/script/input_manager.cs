using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour, Player_control.IPlayerActions
{
	private Player_control inputActions;

	public Vector2 MoveInput { get; private set; }
	public Vector2 LookInput { get; private set; }
	public bool IsAttacking { get; private set; }
	public bool IsInteracting { get; private set; }
	public bool IsCrouching { get; private set; }
	public bool IsJumping { get; private set; }
	public bool IsPreviousPressed { get; private set; }
	public bool IsNextPressed { get; private set; }
	public bool IsSprinting { get; private set; }

	private void Awake()
	{
		inputActions = new Player_control();
		inputActions.Player.SetCallbacks(this);
	}

	private void OnEnable()
	{
		inputActions?.Player.Enable();
	}

	private void OnDisable()
	{
		inputActions?.Player.Disable();
		MoveInput = Vector2.zero;
		LookInput = Vector2.zero;
		IsAttacking = false;
		IsInteracting = false;
		IsCrouching = false;
		IsJumping = false;
		IsPreviousPressed = false;
		IsNextPressed = false;
		IsSprinting = false;
	}

	private void OnDestroy()
	{
		if (inputActions == null)
		{
			return;
		}

		inputActions.Player.SetCallbacks(null);
		inputActions.Dispose();
		inputActions = null;
	}

	public void OnMove(InputAction.CallbackContext context)
	{
		MoveInput = context.ReadValue<Vector2>();
	}

	public void OnLook(InputAction.CallbackContext context)
	{
		LookInput += context.ReadValue<Vector2>();
	}

	public Vector2 ConsumeLookInput()
	{
		Vector2 lookInput = LookInput;
		LookInput = Vector2.zero;
		return lookInput;
	}

	public void OnAttack(InputAction.CallbackContext context)
	{
		IsAttacking = context.ReadValueAsButton();
	}

	public void OnInteract(InputAction.CallbackContext context)
	{
		IsInteracting = context.ReadValueAsButton();
	}

	public void OnCrouch(InputAction.CallbackContext context)
	{
		IsCrouching = context.ReadValueAsButton();
	}

	public void OnJump(InputAction.CallbackContext context)
	{
		IsJumping = context.ReadValueAsButton();
	}

	public void OnPrevious(InputAction.CallbackContext context)
	{
		IsPreviousPressed = context.ReadValueAsButton();
	}

	public void OnNext(InputAction.CallbackContext context)
	{
		IsNextPressed = context.ReadValueAsButton();
	}

	public void OnSprint(InputAction.CallbackContext context)
	{
		IsSprinting = context.ReadValueAsButton();
	}
}
