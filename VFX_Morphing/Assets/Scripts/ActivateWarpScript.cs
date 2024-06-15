using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ActivateWarpScript : MonoBehaviour
{
	[SerializeField]
	private VisualEffect warpEffect;

	public float speedRate = 0.1f;

	private float warpProgress = 0f;
	private bool warpActive = false;

	void Start()
	{
		warpEffect.Stop();
		warpEffect.SetFloat("WarpProgress", 0);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.O))
		{
			warpActive = true;
			StartCoroutine(ActivateWarp());
		}
		else if (Input.GetKeyUp(KeyCode.O))
		{
			warpActive = false;
			StartCoroutine(ActivateWarp());
		}

		warpEffect.SetFloat("WarpProgress", warpProgress);
	}

	private IEnumerator ActivateWarp()
	{
		warpEffect.Play();
		warpProgress = speedRate + warpEffect.GetFloat("WarpProgress");
		while (warpProgress < 1)
		{
			warpProgress += speedRate * Time.deltaTime;
			warpEffect.SetFloat("WarpProgress", warpProgress);
			yield return new WaitForSeconds(0.01f);
		}

		if (!warpActive)
		{
			warpProgress = speedRate + warpEffect.GetFloat("WarpProgress");
			while (warpProgress > 0)
			{
				warpProgress -= speedRate;
				warpEffect.SetFloat("WarpProgress", warpProgress);
				yield return new WaitForSeconds(0.01f);

				if (warpProgress <= speedRate)
					warpEffect.Stop();
			}
		}
	}
}
