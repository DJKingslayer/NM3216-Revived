using UnityEngine;
using System.Collections;

public class EndlessJumpCtrl : MonoBehaviour {

	private EndlessRunnerPlayer endlessPlayer;

	// Use this for initialization
	void Start () {
		endlessPlayer = GameObject.Find("Player").GetComponent<EndlessRunnerPlayer>();

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("GROUND") || other.CompareTag ("Enemies") || other.CompareTag ("Platform")) {
			endlessPlayer.ResetJump ();
		}
	}
}
