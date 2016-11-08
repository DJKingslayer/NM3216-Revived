using UnityEngine;
using System.Collections;

public class EndlessDialogueSelector : MonoBehaviour {

	public TextAsset theText;

	private AlignmentCtrl align;

	public int startLine;
	public int endLine;

	public AudioClip Ding;

	private EndlessTextBoxManager theTextbox;

	public bool DestroyWhenActivated;
	public bool isEnd, hasActivated;
	public bool UseFader;
	public bool FreezePlayer;
	public bool IgnoreEndLine;

	private EndlessSceneFader fader;

	public GameObject Monster;

	private EndlessRunnerPlayer endlessPlayer;

	private SfxCtrl sfx;

	// Use this for initialization
	void Start () 
	{
		theTextbox = FindObjectOfType<EndlessTextBoxManager> ();
		fader = FindObjectOfType<EndlessSceneFader> ();
		endlessPlayer = FindObjectOfType<EndlessRunnerPlayer> ();
		align = FindObjectOfType<AlignmentCtrl> ();
		sfx = FindObjectOfType<SfxCtrl> ();

		hasActivated = false;	
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player") 
		{
			//sfx.PlaySfx (Ding);
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

			if (Monster != null) 
			{
				Monster.SetActive (true);
			}
		}
	}
}

