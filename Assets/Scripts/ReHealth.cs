using UnityEngine;
using System.Collections;

public class ReHealth : MonoBehaviour {

	public bool OneUse;
	public bool DestoryOnUse;

	private bool isUsed;

	private PlayerController playerController;

	private HungerCtrl hunger;

	// Use this for initialization
	void Start () 
	{
		playerController = FindObjectOfType<PlayerController> ();
		hunger = FindObjectOfType<HungerCtrl> ();
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
