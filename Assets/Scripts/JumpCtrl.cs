using UnityEngine;
using System.Collections;

public class JumpCtrl : MonoBehaviour {

	private PlayerController playerController;

	// Use this for initialization
	void Start () {
		playerController = GameObject.Find("Player").GetComponent<PlayerController>();
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("GROUND") || other.CompareTag ("Enemies") || other.CompareTag ("Platform") || other.CompareTag("Obstacle")) {
			playerController.ResetJump ();
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.CompareTag("Enemies")) 
		{
			playerController.ResetJump ();
		}
	} 

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag ("GROUND")) {
			playerController.ResetJump ();			
		}
	}

}
