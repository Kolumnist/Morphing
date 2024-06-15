using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ShootFlameThrower : MonoBehaviour
{
    private VisualEffect flameThrower;

    // Start is called before the first frame update
    void Start()
    {
        if (flameThrower == null)
        {
            flameThrower = GetComponent<VisualEffect>();
        }
        flameThrower.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            flameThrower.Play();
        }
        else if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            flameThrower.Stop();
        }
    }
}
