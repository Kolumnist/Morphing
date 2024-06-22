using UnityEngine;
using UnityEngine.VFX;

public class RestartVFX : MonoBehaviour
{
	private VisualEffect vfx;
	private InputReader inputReader;

	void Start()
	{
		vfx = GetComponent<VisualEffect>();
	}

	private void OnTriggerEnter(Collider player)
	{
		if (!player.CompareTag("Player")) return;
		var playerControllerScript = player.gameObject.GetComponent<PlayerController>();
		playerControllerScript.pressToInteract.SetActive(true);
		inputReader = playerControllerScript.GetInputReader();
		inputReader.Interaction = Restart;
	}

	private void OnTriggerExit(Collider player)
	{
		if (!player.CompareTag("Player")) return;
		var playerControllerScript = player.gameObject.GetComponent<PlayerController>();
		playerControllerScript.pressToInteract.SetActive(false);
		inputReader = playerControllerScript.GetInputReader();
		inputReader.Interaction = null;
	}

	protected void Restart()
	{
		vfx.Reinit();
	}
}
