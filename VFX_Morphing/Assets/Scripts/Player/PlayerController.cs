using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public GameObject pressToInteract;

	public static float move_speed = 4;
	private Vector3 velocity = Vector3.zero;

	private InputReader inputReader;
	public InputReader GetInputReader() { return inputReader; }

	private CharacterController player;
	private Transform mainCamera;
	private Animator animator;

	void Start()
	{
		mainCamera = Camera.main.transform;
		inputReader = GetComponent<InputReader>();
		player = GetComponent<CharacterController>();
		animator = GetComponent<Animator>();

		pressToInteract.SetActive(false);

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	void Update()
	{
		CalculateMove();
		if (!player.isGrounded)
		{
			velocity.y = Physics.gravity.y;
		}
		player.Move(velocity * Time.deltaTime);
		FaceMoveDirection();
	}

	public void FaceMoveDirection()
	{
		Vector3 faceDirection = new(velocity.x, 0f, velocity.z);

		if (faceDirection == Vector3.zero)
			return;

		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(faceDirection), 2*Time.deltaTime);
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
		animator.SetFloat("MoveSpeed", velocity != Vector3.zero ? 0.5f : 0f);
	}
}
