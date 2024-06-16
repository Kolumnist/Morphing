using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ActivateWarpScript : MonoBehaviour
{
	[SerializeField]
	private VisualEffect warpEffect;
	[SerializeField]
	private MeshRenderer warpRenderer;

	public float speedRate = 0.01f;

	private float warpProgress = 0f;
	private bool warpActive = false;

	void Start()
	{
		warpEffect.Stop();
		warpEffect.SetFloat("WarpProgress", 0);
		warpRenderer.material.SetFloat("_WarpProgress", 0);
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
		warpProgress = speedRate + warpEffect.GetFloat("WarpProgress");

		if (warpActive)
		{
			warpEffect.Play();
			while (warpActive && warpProgress < 1)
			{
				warpProgress += warpProgress * warpProgress * warpProgress * warpProgress;
				warpProgress = Mathf.Min(1f, warpProgress);
				warpEffect.SetFloat("WarpProgress", warpProgress);
				warpRenderer.material.SetFloat("_WarpProgress", warpProgress);
				yield return new WaitForSeconds(0.01f);
			}
		}

		while (!warpActive && warpProgress > 0)
		{
			warpProgress -= speedRate;
			warpEffect.SetFloat("WarpProgress", warpProgress);
			warpRenderer.material.SetFloat("_WarpProgress", warpProgress);
			yield return new WaitForSeconds(0.01f);

			if (warpProgress <= speedRate)
			{
				warpProgress = 0;
				warpEffect.SetFloat("WarpProgress", warpProgress);
				warpRenderer.material.SetFloat("_WarpProgress", warpProgress);
				warpEffect.Stop();
			}
		}
	}
}
