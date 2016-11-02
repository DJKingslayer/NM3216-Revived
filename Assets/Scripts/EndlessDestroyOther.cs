using UnityEngine;
using System.Collections;

public class EndlessDestroyOther : MonoBehaviour {

	private EndlessRunnerPlayer endlessPlayer;

	void Awake()
	{
		endlessPlayer = GameObject.Find ("Player").GetComponent<EndlessRunnerPlayer> ();
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.CompareTag("Enemies"))
		{			
			float chance = .5f;

			if (endlessPlayer.isPouncing) 
			{
				chance = 1;
			}

			endlessPlayer.IncHP (chance,1);
			endlessPlayer.CountDeath ();

			Destroy (other.gameObject);
			Destroy (gameObject);
		}

	}

}
