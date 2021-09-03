using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : MonoBehaviour 
{
	
	public float speed;
	public float life;

	void Update () 
	{
		
		this.gameObject.transform.Translate (Vector3.forward * Time.deltaTime * speed);
	}
	void Start ()
	{
		Destroy (this.gameObject, life);
	}
}
