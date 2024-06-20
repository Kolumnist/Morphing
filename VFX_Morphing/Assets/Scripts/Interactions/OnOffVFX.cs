using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class OnOffVFX : MonoBehaviour
{
	private VisualEffect vfx;
	private bool active = true;
	private InputReader inputReader;

    void Start()
	{
		vfx = GetComponent<VisualEffect>();
	}

	private void OnTriggerEnter(Collider player)
	{
		if(!player.CompareTag("Player")) return;
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
        if (active)
        {
			vfx.Stop();
			active = false;
			return;
		}
		vfx.Play();
		active = true;
	}
}
