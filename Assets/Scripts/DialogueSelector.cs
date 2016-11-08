using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DialogueSelector : MonoBehaviour {

	public TextAsset theText;

	private AlignmentCtrl align;

	public int startLine;
	public int endLine;

	public AudioClip Ding;

	private TextBoxManager theTextbox;

	public bool DestroyWhenActivated;
	public bool isEnd, hasActivated;
	public bool UseFader;
	public bool FreezePlayer;
	public bool IgnoreEndLine;

	private SceneFader fader;

	public GameObject Monster;

	private PlayerController playerController;

	private SfxCtrl sfx;


	// Use this for initialization
	void Start () 
	{
		theTextbox = FindObjectOfType<TextBoxManager> ();
		fader = FindObjectOfType<SceneFader> ();
		playerController = FindObjectOfType<PlayerController> ();
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
			sfx.PlaySfx (Ding);
			// normal Running
			if (!isEnd) 
			{
				theTextbox.currentLine = startLine;
				theTextbox.ReloadScript (theText,isEnd);
				hasActivated = true;
								
				if (endLine > 0 || IgnoreEndLine) 
				{
					theTextbox.endAtLine = endLine;
				}
				
				if (endLine == 0 && !IgnoreEndLine) 
				{
					theTextbox.endAtLine = theTextbox.textLines.Length - 1;
				}
			}

			if (isEnd) 
			{
				Scene CheckScene = SceneManager.GetActiveScene ();
				if (CheckScene.name == "Tutorial_Calculation_Portion") 
				{
					align.SetAlign ();
					print ("AlignmentSet");
				}

				theTextbox.ReloadScript (theText,isEnd);
				theTextbox.currentLine = startLine;
				theTextbox.FixEndLine ();

			}

			if (UseFader) 
			{
				fader.IsFaded = false;
				theTextbox.useFader = true;
			} 

			else theTextbox.useFader = false;

			if (DestroyWhenActivated) 
			{
				gameObject.SetActive (false);
			}


			if (FreezePlayer) 
			{
				playerController.MovementFreeze ();
				playerController.CanMove = false;
			}

			if (Monster != null) 
			{
				Monster.SetActive (true);
			}
		}
	}
}

