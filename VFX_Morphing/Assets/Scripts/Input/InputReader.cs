using System;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, PlayerActionControls.IPlayerActions
{
	public Vector2 MouseDelta;
	public Vector2 MoveXZ;

	private PlayerActionControls controls;

	private void OnEnable()
	{
		if (controls != null)
			return;

		controls = new PlayerActionControls();
		controls.Player.SetCallbacks(this);
		controls.Player.Enable();
	}

	public void OnDisable()
	{
		controls.Player.Disable();
	}

	public void OnLook(InputAction.CallbackContext context)
	{
		MouseDelta = context.ReadValue<Vector2>();
	}

	public void OnMove(InputAction.CallbackContext context)
	{
		MoveXZ = context.ReadValue<Vector2>();
	}

	public void OnWarp(InputAction.CallbackContext context)
	{

	}

	public void OnFire(InputAction.CallbackContext context)
	{
		throw new NotImplementedException();
	}
}