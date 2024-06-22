using UnityEngine;
using UnityEngine.VFX;

public class ChangeSDFModel : MonoBehaviour
{
    [SerializeField]
    private Texture3D textureSDF;
    [SerializeField]
    private VisualEffect effectSDF;

	private InputReader inputReader;

	private void OnTriggerEnter(Collider player)
	{
		if (!player.CompareTag("Player")) return;
		var playerControllerScript = player.gameObject.GetComponent<PlayerController>();
		playerControllerScript.pressToInteract.SetActive(true);
		inputReader = playerControllerScript.GetInputReader();
		inputReader.Interaction = SwitchSDFTexture;
	}

	private void OnTriggerExit(Collider player)
	{
		if (!player.CompareTag("Player")) return;
		var playerControllerScript = player.gameObject.GetComponent<PlayerController>();
		playerControllerScript.pressToInteract.SetActive(false);
		inputReader = playerControllerScript.GetInputReader();
		inputReader.Interaction = null;
	}

	protected void SwitchSDFTexture()
	{
		effectSDF.SetTexture("SDF", textureSDF);
	}
}
