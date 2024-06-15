using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	[SerializeField]
	private CharacterController player;

	[SerializeField]
	private Transform mainCamera;
	public static float move_speed = 5;
	private Vector3 velocity = Vector3.zero;


	private InputReader inputReader;

	void Start()
	{
		mainCamera = Camera.main.transform;
		inputReader = GetComponent<InputReader>();
		player = GetComponent<CharacterController>();
	}

	void Update()
	{
		CalculateMove();
		player.Move(velocity * Time.deltaTime);
	}

	public void CalculateMove()
	{
		Vector3 cameraForward = new(mainCamera.forward.x, 0, mainCamera.forward.z);
		Vector3 cameraRight = new(mainCamera.right.x, 0, mainCamera.right.z);

		Vector3 moveDirection = cameraForward.normalized * inputReader.MoveXZ.y + cameraRight.normalized * inputReader.MoveXZ.x;

		velocity = new()
		{
			x = moveDirection.x * move_speed,
			y = 0,
			z = moveDirection.z * move_speed
		};
	}
}
