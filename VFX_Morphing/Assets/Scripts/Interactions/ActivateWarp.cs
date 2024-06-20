using Cinemachine;
using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

public class ActivateWarp : MonoBehaviour
{
	[SerializeField]
	private MeshRenderer warpRenderer;
	[SerializeField]
	private CinemachineVirtualCamera virtualCamera;

	public float speedRate = 0.01f;

	private VisualEffect warpEffect;
	private CinemachineBasicMultiChannelPerlin channel;
	private InputReader inputReader;

	private float warpProgress = 0f;
	private bool warpActive = false;

	void Start()
	{
		warpEffect = GetComponent<VisualEffect>();
		warpEffect.Stop();
		warpEffect.SetFloat("WarpProgress", 0);

		channel = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
		channel.m_AmplitudeGain = 0f;
		warpRenderer.material.SetFloat("_WarpProgress", 0);
	}

	void Update()
	{
		warpEffect.SetFloat("WarpProgress", warpProgress);
	}

	private IEnumerator Activate()
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
				channel.m_AmplitudeGain = warpProgress;

				yield return new WaitForSeconds(0.01f);
			}
		}

		while (!warpActive && warpProgress > 0)
		{
			warpProgress -= speedRate;
			warpEffect.SetFloat("WarpProgress", warpProgress);
			warpRenderer.material.SetFloat("_WarpProgress", warpProgress);
			channel.m_AmplitudeGain = warpProgress;
			yield return new WaitForSeconds(0.01f);

			if (warpProgress <= speedRate)
			{
				warpProgress = 0;
				warpEffect.SetFloat("WarpProgress", warpProgress);
				warpRenderer.material.SetFloat("_WarpProgress", warpProgress);
				channel.m_AmplitudeGain = warpProgress;
				warpEffect.Stop();
			}
		}
	}

	private void OnTriggerEnter(Collider player)
	{
		if (!player.CompareTag("Player")) return;
		var playerControllerScript = player.gameObject.GetComponent<PlayerController>();
		playerControllerScript.pressToInteract.SetActive(true);
		inputReader = playerControllerScript.GetInputReader();
		inputReader.Interaction = WarpSwitch;
	}

	private void OnTriggerExit(Collider player)
	{
		if (!player.CompareTag("Player")) return;
		var playerControllerScript = player.gameObject.GetComponent<PlayerController>();
		playerControllerScript.pressToInteract.SetActive(false);
		inputReader = playerControllerScript.GetInputReader();
		inputReader.Interaction = null;
	}

	protected void WarpSwitch()
	{
		if (!warpActive)
		{
			warpActive = true;
			StartCoroutine(Activate());
			return;
		}
		else if (warpActive)
		{
			warpActive = false;
			StartCoroutine(Activate());
		}
	}
}
