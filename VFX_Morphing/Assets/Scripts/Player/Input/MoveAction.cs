using UnityEngine;

public static class MoveAction
{
	public static float move_speed = 5;

	public static void Move(CharacterController player, Transform camera, Vector2 context)
	{
		Vector3 cameraForward = new(camera.forward.x, 0, camera.forward.z);
		Vector3 cameraRight = new(camera.right.x, 0, camera.right.z);

		Vector3 moveDirection = cameraForward.normalized * context.y + cameraRight.normalized * context.x;

		Vector3 velocity = new()
		{
			x = moveDirection.x * move_speed,
			z = moveDirection.z * move_speed
		};

		player.Move(velocity * Time.deltaTime);
	}
}
