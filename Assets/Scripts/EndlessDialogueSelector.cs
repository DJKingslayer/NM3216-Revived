using UnityEngine;
using System.Collections;

public class EndlessDialogueSelector : MonoBehaviour {

	public TextAsset theText;

	private AlignmentCtrl align;

	public int startLine;
	public int endLine;
	public int GoodStart, GoodEnd;
	public int BadStart, BadEnd;

	public EndlessTextBoxManager theTextbox;

	public bool DestroyWhenActivated;
	public bool isEnd, hasActivated;
	public bool UseFader;
	public bool FreezePlayer;

	private EndlessSceneFader fader;

	public GameObject Monster;

	private EndlessRunnerPlayer endlessPlayer;


	// Use this for initialization
	void Start () 
	{
		theTextbox = FindObjectOfType<EndlessTextBoxManager> ();
		fader = FindObjectOfType<EndlessSceneFader> ();
		endlessPlayer = FindObjectOfType<EndlessRunnerPlayer> ();
		align = FindObjectOfType<AlignmentCtrl> ();

		hasActivated = false;	
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player") 
		{
			// normal Running
			if (!isEnd) 
			{
				theTextbox.currentLine = startLine;
				hasActivated = true;
				theTextbox.ReloadScript (theText,isEnd);

				if (endLine != 0) 
				{
					theTextbox.endAtLine = endLine;
				}

				if (endLine == 0) 
				{
					theTextbox.endAtLine = theTextbox.textLines.Length - 1;
				}
			}

			if (isEnd) 
			{
				align.SetAlign ();
				theTextbox.ReloadScript (theText,isEnd);

				if (!PlayerData.IsKiller) 
				{
					theTextbox.currentLine = GoodStart;
					theTextbox.endAtLine = GoodEnd;
				}

				if (PlayerData.IsKiller) 
				{
					theTextbox.currentLine = BadStart;
					theTextbox.endAtLine = BadEnd;
				}

			}

			if (UseFader) 
			{
				fader.IsFaded = false;
				theTextbox.useFader = true;
			} 

			else theTextbox.useFader = false;

			if (DestroyWhenActivated) 
			{
				Destroy (gameObject);
			}


			if (FreezePlayer) 
			{
				endlessPlayer.MovementFreeze ();
				endlessPlayer.CanMove = false;
			}
		}
	}
}

