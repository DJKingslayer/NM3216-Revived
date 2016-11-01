using UnityEngine;
using System.Collections;

public class ReHealth : MonoBehaviour {

	public bool OneUse;
	public bool DestoryOnUse;

	public AudioClip Gulp;

	private bool isUsed;

	private PlayerController playerController;

	private HungerCtrl hunger;

	private SfxCtrl sfx;

	// Use this for initialization
	void Start () 
	{
		playerController = FindObjectOfType<PlayerController> ();
		hunger = FindObjectOfType<HungerCtrl> ();

		sfx = FindObjectOfType<SfxCtrl> ();

		isUsed = false;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player") 
		{
			if (!isUsed) 
			{
				playerController.IncHP (1, 1);
				hunger.EatBerry ();
				sfx.PlaySfx (Gulp);
			}

			if (OneUse) 
			{			
				isUsed = true;
				
				if (DestoryOnUse) 
				{
					Destroy (gameObject);
				}
			}
		}	


		

	}
}
