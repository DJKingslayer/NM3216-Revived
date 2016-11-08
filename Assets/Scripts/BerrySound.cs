using UnityEngine;
using System.Collections;

public class BerrySound : MonoBehaviour {

	public AudioClip Gulp;

	private SfxCtrl sfx;

	// Use this for initialization
	void Start () 
	{
		sfx = FindObjectOfType<SfxCtrl> ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player") 
		{
			sfx.PlaySfx (Gulp);
		}
	}
}
