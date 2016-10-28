using UnityEngine;
using System.Collections;

public class StoryDialogue : MonoBehaviour {

	[SerializeField]
	private int counter,counterB;
	private SfxCtrl sfx;

	private AudioSource source;

	public int growlNo;

	public AudioClip growl;
	public AudioClip sadHowl;

	// Use this for initialization
	void Start () {
		counter = 0;
		counterB = 0;
		sfx = FindObjectOfType<SfxCtrl> ();
		source = gameObject.GetComponent<AudioSource> ();	
	}
	
	// Update is called once per frame
	void Update () {
		if (counter == growlNo)
		{
			Invoke ("delayGrowl", 3);				
			counter -= growlNo;
			print ("growl");
		}

		if (PlayerData.IsKiller) 
		{
			if (counterB == 25) 
			{
				Invoke ("delayHowl", 3);				
				print ("sadhowl");
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
