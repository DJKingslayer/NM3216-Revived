using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StoryDialogue : MonoBehaviour {

	[SerializeField]
	private int counter,counterB;

	private AudioSource source;

	public int StoryProceed;

	public AudioClip growl;
	public AudioClip sadHowl;

	public int TotalEnemies;

	private TextBoxManager textBoxManager;

	public TextAsset FenrirText;

	public Sprite Head1,Head2,Head3;

	private PlayerController playerController;

	private Image dialogueSprite;

	// Use this for initialization
	void Start () {
		counter = 0;
		counterB = 0;
		source = gameObject.GetComponent<AudioSource> ();

		textBoxManager = FindObjectOfType<TextBoxManager> ();

		playerController = FindObjectOfType<PlayerController> ();

		dialogueSprite = GameObject.Find ("Dialogue Picture").GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (counter == StoryProceed && counterB > 0)
		{
			Invoke ("delayGrowl", 3);				
			counter -= StoryProceed;
			counterB += 1;

			textBoxManager.ReloadScript (FenrirText, false);

			textBoxManager.currentLine = counterB - 1;
			textBoxManager.endAtLine = counterB;

			textBoxManager.useFader = false;

			loadHead ();

			playerController.SavePosition ();

		}

		if (playerController.Fenrir && !playerController.Iri) 
		{
			if (counterB == 5) 
			{
				Invoke ("delayHowl", 3);
				counterB = -1;
			}
		}

		if (counter == TotalEnemies) 
		{
			textBoxManager.ReloadScript (FenrirText, true);

			textBoxManager.currentLine = 5;
			textBoxManager.endAtLine = 5;

			textBoxManager.useFader = false;
		}

	}

	public void CountMarker()
	{
		counter += 1;
	}

	void delayGrowl()
	{
		source.PlayOneShot (growl);
	}

	void delayHowl()
	{
		source.PlayOneShot (sadHowl);
	}

	void loadHead()
	{
		if (counterB <= 2) 
		{
			dialogueSprite.sprite = Head1;
		}

		if (counterB == 3) 
		{
			dialogueSprite.sprite = Head2;
		}

		if (counterB >= 5) 
		{
			dialogueSprite.sprite = Head3;
		}

	}
}
