using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour 
{
	public bool firstplayer;

	//public GameObject playerone;
	//public GameObject playertwo;

	// transform.localScale += new Vector3(0.1F, 0, 0);
	void OnTriggerEnter (Collider other)
	{
		if (firstplayer) 
		{
			if (other.gameObject.tag == "playeroneplayer") {
				//playerone.GetComponent<MoveCube> ().health -= 1;
				GameObject.Find ("Player1").GetComponent<MoveCube> ().health -= 1;
			} else {
				Destroy (this.gameObject);
			}
		}
		if (!(firstplayer))
		{
			if (other.gameObject.tag == "playertwoplayer") {
				GameObject.Find ("Player2").GetComponent<Playertwo> ().health -= 1;
			} else {
				Destroy (this.gameObject);
			}
		}
	}


}
