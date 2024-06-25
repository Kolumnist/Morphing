using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ActivateOthers : MonoBehaviour
{
	[SerializeField]
	private VisualEffect[] vfxs;

	private bool active = false;
	private InputReader inputReader;

	void Start()
	{
		foreach(var vfx in vfxs)
		{
			vfx.Stop();
		}
	}

	private void OnTriggerEnter(Collider player)
	{
		if (!player.CompareTag("Player")) return;
		var playerControllerScript = player.gameObject.GetComponent<PlayerController>();
		playerControllerScript.pressToInteract.SetActive(true);
		inputReader = playerControllerScript.GetInputReader();
		inputReader.Interaction = OnOff;
	}

	private void OnTriggerExit(Collider player)
	{
		if (!player.CompareTag("Player")) return;
		var playerControllerScript = player.gameObject.GetComponent<PlayerController>();
		playerControllerScript.pressToInteract.SetActive(false);
		inputReader = playerControllerScript.GetInputReader();
		inputReader.Interaction = null;
	}

	protected void OnOff()
	{
		foreach (var vfx in vfxs)
		{
			if (active)
			{
				vfx.Stop();
			}
			else
			{
				vfx.Play();
			}
		}
		active = !active;
	}
}
