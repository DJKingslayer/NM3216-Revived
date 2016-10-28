using UnityEngine;
using System.Collections;

public class SfxCtrl : MonoBehaviour {

	public AudioClip BirdDeath;
	public AudioClip BirdEntrance;
	public AudioClip SnakeDeath;
	public AudioClip Growl;
	public AudioClip SadHowl;

	private AudioSource source;

	// Use this for initialization
	void Start () 
	{
		source = gameObject.GetComponent<AudioSource> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlaySfx (AudioClip Sound) {
		source.PlayOneShot (Sound);
	}

}
