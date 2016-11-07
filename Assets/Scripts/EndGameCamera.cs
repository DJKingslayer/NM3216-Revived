using UnityEngine;
using System.Collections;

public class EndGameCamera : MonoBehaviour {

	private Rigidbody2D rb;

	public float ScrollSpeed;

	// Use this for initialization
	void Start () 
	{
		rb = gameObject.GetComponent<Rigidbody2D> ();

		rb.velocity = new Vector2 (0, ScrollSpeed);
	}
	
	// Update is called once per frame
	void Update () 
	{
//		if (Input.GetKeyDown (KeyCode.Space)) 
//		{
//			rb.velocity = new Vector2 (0, ScrollSpeed);
//		}

		Vector3 temp = transform.position;
		temp.y = Mathf.Clamp (transform.position.y,-28.75f, -0.19f);
		transform.position = temp;
	}
}
