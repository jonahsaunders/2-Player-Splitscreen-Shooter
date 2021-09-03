using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveCube : MonoBehaviour 
{
	//current health divided by max health = x, this.scale.z, this.scale.y
	private float speed;
	public float sprintspeed;
	public float normalspeed;
	//public float jump;
	public float rotatespeed;


	public GameObject bulletprefab;
	public GameObject gunforward;
	public GameObject gunright;
	public GameObject gunleft;

	public AudioClip shoot;

	public GameObject healthbar;

	public GameObject origin;

	public Rigidbody rb;

	public float jumppower;


	public float maxhealth;
	public float health;
	public float currentlengthhealth;

	public Text healthtext;

	public GameObject playeronewins;

	public bool canjump;

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent <Rigidbody> ();
		//InvokeRepeating("Reset", 5.0f, 5.0f);
	}
	/*
	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.tag == "playertwo")
		{
			health -= 1;
		}
	}
	*/
	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.tag == "speedboost")
		{
			other.gameObject.SetActive (false);
			StartCoroutine ("speedy");
		}
		if(other.gameObject.tag == "jump")
		{
			Destroy (other.gameObject);
			StartCoroutine ("allowjump");
		}
	}
	void OnTriggerStay (Collider other)
	{
		if (other.gameObject.tag == "Ground") 
		{
			//Debug.Log ("hitting ground");
			if (Input.GetKeyUp ("f") && (canjump))
			{
				rb.AddForce (transform.up * jumppower);
			}
		}
	}
	// Update is called once per frame
	IEnumerator speedy ()
	{
		sprintspeed *= 2;
		normalspeed *= 2;
		yield return new WaitForSeconds (5);
		sprintspeed /= 2;
		normalspeed /= 2;
	}
	IEnumerator allowjump ()
	{
		canjump = true;
		yield return new WaitForSeconds (5);
		canjump = false;
	}
	IEnumerator Reset ()
	{
		yield return new WaitForSeconds (5);
		SceneManager.LoadScene(0);
	}
	void Update () 
	{

		currentlengthhealth = (health / maxhealth) * 100f;
		healthbar.transform.localScale = new Vector3(currentlengthhealth, 173, 173);
		healthtext.text = "Health: " + health.ToString ();
		if (health <= 0) 
		{
			playeronewins.SetActive (true);
			StartCoroutine ("Reset");
		}
		if (Input.GetKey ("w"))
		{
			this.gameObject.transform.Translate (Vector3.forward * Time.deltaTime * speed);
		}
		if (Input.GetKey ("d"))
		{
			this.gameObject.transform.Translate (Vector3.right * Time.deltaTime * speed);
		}
		if (Input.GetKey ("a"))
		{
			this.gameObject.transform.Translate (Vector3.left * Time.deltaTime * speed);
		}
		if (Input.GetKey ("s"))
		{
			this.gameObject.transform.Translate (Vector3.back * Time.deltaTime * speed);
		}
		if (Input.GetKey ("e"))
		{
			this.gameObject.transform.Rotate (Vector3.up * Time.deltaTime * rotatespeed);
		}
		if (Input.GetKey ("q"))
		{
			this.gameObject.transform.Rotate (Vector3.down * Time.deltaTime * rotatespeed);
		}
		/*
		if (Input.GetKey ("space"))
		{
			this.gameObject.transform.Translate (Vector3.up * Time.deltaTime * jump);
		}
		*/

		//		if (Input.GetMouseButtonDown (0))
		if (Input.GetKeyUp("r"))
		{
			Instantiate (bulletprefab, gunforward.transform.position, this.gameObject.transform.rotation);
			AudioSource.PlayClipAtPoint(shoot, transform.position);
		}
		if (Input.GetKeyUp("r"))
		{
			GameObject bullet = Instantiate (bulletprefab) as GameObject;
			bullet.transform.position = gunright.gameObject.transform.position;
			bullet.transform.rotation = this.gameObject.transform.rotation;
			AudioSource.PlayClipAtPoint(shoot, transform.position);
		}
		if (Input.GetKeyUp("r"))
		{
			GameObject bullet = Instantiate (bulletprefab) as GameObject;
			bullet.transform.position = gunleft.gameObject.transform.position;
			bullet.transform.rotation = this.gameObject.transform.rotation;
			AudioSource.PlayClipAtPoint(shoot, transform.position);
		}



		if ((Input.GetKey ("c")))
			{
				speed = sprintspeed;
			}
			else
			{
				speed = normalspeed;
			}
	}
	/*
	void Reset ()
	{
		this.gameObject.transform.position = origin.transform.position;
	}
	*/
}
