using OpenCover.Framework.Model;
using System;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, PlayerActionControls.IPlayerActions
{
	public Vector2 MouseDelta;
	public Vector2 MoveXZ;

	[DoNotSerialize]
	public Action Interaction { get; set; }

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

	public void OnFire(InputAction.CallbackContext context)
	{
		return;
	}

	public void OnInteract(InputAction.CallbackContext context)
	{
		if (context.started && Interaction != null)
		{
			Interaction();
		}
		return;
	}
}