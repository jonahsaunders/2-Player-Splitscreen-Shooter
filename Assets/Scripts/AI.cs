using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour 
{
	//give this object the navmesh agent and back environment

	public Transform destination;
	public float distance;
	private UnityEngine.AI.NavMeshAgent agent;
	private UnityEngine.AI.NavMeshAgent navMeshAgent;

	// Use this for initialization
	void Awake () 
	{
		destination = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
		agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent> ();
		agent.SetDestination (destination.position);
		distance = GetComponent<UnityEngine.AI.NavMeshAgent> ().remainingDistance;

	}
}
