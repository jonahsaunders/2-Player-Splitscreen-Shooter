﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour 
{
	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.tag == "enemy")
		{
			Destroy(other.gameObject);
		}
	}
}
