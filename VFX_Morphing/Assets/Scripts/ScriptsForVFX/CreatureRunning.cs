using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

public class CircularMovement : MonoBehaviour
{
    [SerializeField]
    private SkinnedMeshRenderer erodeMesh;

    //Both Values HAVE TO BE THE SAME LENGTH
    public Vector3[] spawnPositions;
    public Quaternion[] spawnRotations;

	public float erodeRate = 0.03f;
    public float erodeRefreshRate = 0.01f;
    public float erodeDelay = 1.25f;

    public float moveSpeed = 2.15f;

    private VisualEffect particleTrail;
    private Vector2 velocity;

    private bool visible = true;

    void Start()
    {
        particleTrail = GetComponent<VisualEffect>();

        velocity = new Vector2(moveSpeed, moveSpeed);
		velocity *= new Vector2(transform.forward.x, transform.forward.z);
		StartCoroutine(ErodeObject());
    }

    void Update()
    {
        if (visible)
        {
            transform.position += new Vector3(velocity.x * Time.deltaTime, 0, velocity.y * Time.deltaTime);
        }
    }

    // I mean I could put the for somewhere else but this class doesnt need to be optimized

    IEnumerator ErodeObject()
    {
        yield return new WaitForSeconds(erodeDelay);

        float erosion = 0;
		while (erosion < 1)
		{
            erosion += erodeRate;
            erodeMesh.material.SetFloat("_Erosion", erosion);
            yield return new WaitForSeconds(erodeRefreshRate);
        }
        visible = false;
        particleTrail.Stop();
        StartCoroutine(ShiftToNewPosition());
	}

    IEnumerator ShiftToNewPosition()
    {
        yield return new WaitForSeconds(6);
        int randomIndex = (int)Random.Range(0.9f, spawnPositions.Length);
        transform.SetPositionAndRotation(spawnPositions[randomIndex], spawnRotations[randomIndex]);

		visible = true;
		particleTrail.Play();
		velocity = new Vector2(moveSpeed, moveSpeed); 
        velocity *= new Vector2(transform.forward.x, transform.forward.z);

		float erosion = 1;
		while (erosion > 0)
		{
			erosion -= erodeRate;
			erodeMesh.material.SetFloat("_Erosion", erosion);
			yield return new WaitForSeconds(erodeRefreshRate);
		}

        StartCoroutine(ErodeObject());
	}
}
