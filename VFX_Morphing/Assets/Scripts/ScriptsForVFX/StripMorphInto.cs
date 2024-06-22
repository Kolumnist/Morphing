using UnityEngine;
using UnityEngine.VFX;

public class StripMorphInto : MonoBehaviour
{
    public Texture3D[] two_sdfs;

    private VisualEffect vfx;
    private float positionY;

    // Start is called before the first frame update
    void Start()
    {
        vfx = GetComponent<VisualEffect>();
		positionY = vfx.GetVector3("TransformationPosition").y;
	}

	// Update is called once per frame
	void Update()
    {
        if (positionY < 1.2f)
        {
            positionY += 0.15f*Time.deltaTime;
            vfx.SetVector3("TransformationPosition", new Vector3(0, positionY, 0));
		}
        else
        {
            Invoke(nameof(SwitchSDF), 6);
        }

    }

    private void SwitchSDF()
    {
        vfx.SetTexture("MorphIntoSDF", two_sdfs[(int)positionY]);
        Invoke(nameof(LowerY), 6);
    }

    private void LowerY()
    {
        while(positionY > 0)
        {
			positionY -= 0.15f * Time.deltaTime;
			vfx.SetVector3("TransformationPosition", new Vector3(0, positionY, 0));
		}
	}
}
