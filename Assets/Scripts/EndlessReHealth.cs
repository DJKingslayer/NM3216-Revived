using UnityEngine;
using System.Collections;

public class EndlessReHealth : MonoBehaviour {

	public bool OneUse;
	public bool DestoryOnUse;

	private bool isUsed;

	private SoundFX sFX;

	private EndlessRunnerPlayer endlessPlayer;

	// Use this for initialization
	void Start () 
	{
		endlessPlayer = FindObjectOfType<EndlessRunnerPlayer> ();
		sFX = FindObjectOfType<SoundFX> ();
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
				endlessPlayer.IncHP (1, 4); 
				sFX.PlaySFX (sFX.Ding, 1, 1);
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
