using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
	public GameObject speedpowerup;
	public GameObject jumppowerup;

	void Start () 
	{
		StartCoroutine (dopowerup ());
	}
	public IEnumerator dopowerup ()
	{
		
		Vector3 position = new Vector3 (Random.Range(-10,10),5.5f, (Random.Range(-10,10)));
		Instantiate (speedpowerup, position, Quaternion.identity);
		Instantiate (jumppowerup, position, Quaternion.identity);
		yield return new WaitForSeconds (5);
	}


}
