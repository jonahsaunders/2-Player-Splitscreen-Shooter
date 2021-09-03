using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour 
{
	public float xspeed;
	private float xrotate;
	public float xclamp;

	// Update is called once per frame
	void Update () 
	{
		//transform.Rotate (new Vector3 (0, Input.GetAxis ("Mouse X"), 0) * Time.deltaTime * xspeed);

		xrotate += Input.GetAxis ("Mouse X") * xspeed;

		xrotate = Mathf.Clamp (xrotate, -(xclamp), (xclamp));
		transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, xrotate, transform.localEulerAngles.z);
	}
}
