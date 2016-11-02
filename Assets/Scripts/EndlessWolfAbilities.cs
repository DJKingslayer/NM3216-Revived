using UnityEngine;
using System.Collections;

public class EndlessWolfAbilities : MonoBehaviour {

	//public GameObject Player;

	private EndlessRunnerPlayer endlessPlayer;

	// Use this for initialization
	void Start () {
		endlessPlayer = GameObject.Find("Player").GetComponent<EndlessRunnerPlayer> ();
	}

	// Update is called once per frame
	void Update () {
		
		if (!endlessPlayer.isPouncing && !endlessPlayer.Attacking) 
		{		
			Destroy (gameObject);
		}

		if (endlessPlayer.Attacking) 
		{
			Destroy (gameObject, .5f);
		}
	}
}
