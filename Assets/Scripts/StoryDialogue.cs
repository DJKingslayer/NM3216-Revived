using UnityEngine;
using System.Collections;

public class StoryDialogue : MonoBehaviour {

	[SerializeField]
	private int counter,counterB;

	private AudioSource source;

	public int GrownNum;

	public AudioClip growl;
	public AudioClip sadHowl;

	// Use this for initialization
	void Start () {
		counter = 0;
		counterB = 0;
		source = gameObject.GetComponent<AudioSource> ();	
	}
	
	// Update is called once per frame
	void Update () {
		if (counter == GrownNum)
		{
			Invoke ("delayGrowl", 3);				
			counter -= GrownNum;
		}

		if (PlayerData.IsKiller) 
		{
			if (counterB == 25) 
			{
				Invoke ("delayHowl", 3);				
			}
		}

	}

	public void CountMarker()
	{
		counter += 1;
		counterB += 1;
	}

	void delayGrowl()
	{
		source.PlayOneShot (growl);
	}

	void delayHowl()
	{
		source.PlayOneShot (sadHowl);
	}
}
