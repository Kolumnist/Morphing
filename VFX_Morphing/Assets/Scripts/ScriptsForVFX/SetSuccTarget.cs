using UnityEngine;
using UnityEngine.VFX;

public class SetSuccTarget : MonoBehaviour
{
	private VisualEffect vfx;
	private PlayerController playerControllerScript;
	
	void Start()
	{
		vfx = GetComponent<VisualEffect>();
	}

	private void Update()
	{
        if (playerControllerScript != null)
        {
			vfx.SetVector3("SuccTarget", playerControllerScript.gameObject.transform.position - transform.position + new Vector3(0,1.45f,0));
		}
    }

	private void OnTriggerEnter(Collider player)
	{
		if (!player.CompareTag("Player")) return;
		playerControllerScript = player.gameObject.GetComponent<PlayerController>();
	}

	private void OnTriggerExit(Collider player)
	{
		if (!player.CompareTag("Player")) return;
		playerControllerScript = null;
		vfx.SetVector3("SuccTarget", Vector3.zero);
	}
}
