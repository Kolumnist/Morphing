using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
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

	public void OnFire(InputAction.CallbackContext context)
	{
		if (context.started)
		{
			flameThrower.Play();
		}
		else if (context.canceled)
		{
			flameThrower.Stop();
		}
	}
}
