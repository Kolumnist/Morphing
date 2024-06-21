using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ToggleFlamethrower : MonoBehaviour
{
    [SerializeField]
	private VisualEffect normalFlamethrower;
    [SerializeField]
	private VisualEffect healFlamethrower;

	private bool healActive = true;
	private InputReader inputReader;

	private void OnTriggerEnter(Collider player)
	{
		if (!player.CompareTag("Player")) return;
		var playerControllerScript = player.gameObject.GetComponent<PlayerController>();
		playerControllerScript.pressToInteract.SetActive(true);
		inputReader = playerControllerScript.GetInputReader();
		inputReader.Interaction = Toggle;
	}

	private void OnTriggerExit(Collider player)
	{
		if (!player.CompareTag("Player")) return;
		var playerControllerScript = player.gameObject.GetComponent<PlayerController>();
		playerControllerScript.pressToInteract.SetActive(false);
		inputReader = playerControllerScript.GetInputReader();
		inputReader.Interaction = null;
	}

	protected void Toggle()
	{
		if (healActive)
		{
			healFlamethrower.Stop();
			normalFlamethrower.Play();
			healActive = false;
			return;
		}
		healFlamethrower.Play();
		normalFlamethrower.Stop();
		healActive = true;
	}
}
