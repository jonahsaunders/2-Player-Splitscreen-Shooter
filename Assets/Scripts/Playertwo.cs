using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Playertwo : MonoBehaviour 
{
	private float speed;
	public float sprintspeed;
	public float normalspeed;
	//public float jump;
	public float rotatespeed;

	public GameObject bulletprefab;
	public GameObject gunforward;
	public GameObject gunright;
	public GameObject gunleft;

	public GameObject healthbar;

	public AudioClip shoot;

	public GameObject origin;

	public Rigidbody rb;

	public float jumppower;

	public float maxhealth;
	public float health;
	public float currentlengthhealth;
	public Text healthtext;

	public bool canjump;

	public GameObject playertwowins;

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent < Rigidbody> ();
		//InvokeRepeating("Reset", 5.0f, 5.0f);
	}
	/*
	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.tag == "playerone")
		{
			Destroy (other.gameObject);
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
			Debug.Log ("hitting ground");
			if (Input.GetKeyUp ("l") && (canjump))
			{
				rb.AddForce (transform.up * jumppower);
			}
		}
	}
	// Update is called once per frame
	IEnumerator Reset ()
	{
		yield return new WaitForSeconds (5);
		SceneManager.LoadScene(0);
	}
	IEnumerator allowjump ()
	{
		canjump = true;
		yield return new WaitForSeconds (5);
		canjump = false;
	}
	IEnumerator speedy ()
	{
		sprintspeed *= 2;
		normalspeed *= 2;
		yield return new WaitForSeconds (5);
		sprintspeed /= 2;
		normalspeed /= 2;
	}
	void Update () 
	{
		currentlengthhealth = (health / maxhealth) * 100f;
		healthbar.transform.localScale = new Vector3(currentlengthhealth, 173, 173);
		healthtext.text = "Health: " + health.ToString ();
		if (health <= 0) 
		{
			playertwowins.SetActive (true);
			StartCoroutine ("Reset");
		}
		if (Input.GetKey ("u"))
		{
			this.gameObject.transform.Translate (Vector3.forward * Time.deltaTime * speed);
		}
		if (Input.GetKey ("k"))
		{
			this.gameObject.transform.Translate (Vector3.right * Time.deltaTime * speed);
		}
		if (Input.GetKey ("h"))
		{
			this.gameObject.transform.Translate (Vector3.left * Time.deltaTime * speed);
		}
		if (Input.GetKey ("j"))
		{
			this.gameObject.transform.Translate (Vector3.back * Time.deltaTime * speed);
		}
		if (Input.GetKey ("i"))
		{
			this.gameObject.transform.Rotate (Vector3.up * Time.deltaTime * rotatespeed);
		}
		if (Input.GetKey ("y"))
		{
			this.gameObject.transform.Rotate (Vector3.down * Time.deltaTime * rotatespeed);
		}
		/*
		if (Input.GetKey ("space"))
		{
			this.gameObject.transform.Translate (Vector3.up * Time.deltaTime * jump);
		}
		*/

		if (Input.GetKeyUp ("o"))
		{
			Instantiate (bulletprefab, gunforward.transform.position, this.gameObject.transform.rotation);
			AudioSource.PlayClipAtPoint(shoot, transform.position);
		}


		if (Input.GetKeyUp ("o"))
		{
			GameObject bullet = Instantiate (bulletprefab) as GameObject;
			bullet.transform.position = gunright.gameObject.transform.position;
			bullet.transform.rotation = this.gameObject.transform.rotation;
			AudioSource.PlayClipAtPoint(shoot, transform.position);
		}
		if (Input.GetKeyUp ("o"))
		{
			GameObject bullet = Instantiate (bulletprefab) as GameObject;
			bullet.transform.position = gunleft.gameObject.transform.position;
			bullet.transform.rotation = this.gameObject.transform.rotation;
			AudioSource.PlayClipAtPoint(shoot, transform.position);
		}



		if ((Input.GetKeyDown ("l")))
		{
			speed = sprintspeed;
		}
		else
		{
			speed = normalspeed;
		}
	}
}
