using UnityEngine;
using System.Collections;

public class MusicStop : MonoBehaviour {

	public GameObject Mother;

	public AudioSource source;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name == "Player")
		{
			source.Pause();
			Mother.SetActive (true);
		}
	}
}
