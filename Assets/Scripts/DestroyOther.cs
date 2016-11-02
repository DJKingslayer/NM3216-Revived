using UnityEngine;
using System.Collections;

public class DestroyOther : MonoBehaviour {

	private PlayerController playerController;

	private StoryDialogue story;

	void Awake()
	{
		playerController = GameObject.Find ("Player").GetComponent<PlayerController> ();
		story = FindObjectOfType<StoryDialogue> ();
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.CompareTag("Enemies"))
		{			
			float chance = .5f;

			if (playerController.isPouncing) 
			{
				chance = 1;
			}

			playerController.IncHP (chance,1);
			playerController.CountDeath ();

//			Destroy (other.gameObject);
			Destroy (gameObject);


		}

		// Please Add playerdata.iskiller
		if (playerController.Fenrir) 
		{
			if (other.gameObject.CompareTag ("Marker")) 
			{
				float chance = .5f;
			
				if (playerController.isPouncing) {
					chance = 1;
				}
			
				playerController.IncHP (chance, 1);
				playerController.CountDeath ();
			
				story.CountMarker ();
			
				Destroy (gameObject);
			}
		}

	}
		
}
