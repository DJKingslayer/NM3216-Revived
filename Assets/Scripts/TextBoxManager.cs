﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour 
{

	public GameObject textBox;
	public GameObject DialogueBox;

	public Text theText;
	public Text DialogueText;

	public TextAsset textFile;
	public string [] textLines;

	public int currentLine;
	public int endAtLine;

	public bool DisableMovement;
	public bool endOfStage;
	public bool useFader;

	public bool LastScene;

	[SerializeField]
	private bool isTalking;

	private PlayerController playerController;

	private SceneFader fader;

	[SerializeField]
	private EndFader eFader;

	// Use this for initialization
	void Start () 
	{
		if (GameObject.Find("Player") != null) 
		{
			playerController = GameObject.Find ("Player").GetComponent<PlayerController> ();
		}

		if (!LastScene) 
		{
			fader = GameObject.Find ("Cover").GetComponent<SceneFader> ();
		}

		if (LastScene) 
		{
			eFader = FindObjectOfType<EndFader> ();
		}


		if (textFile != null) 
		{
			textLines = (textFile.text.Split ('\n'));	
		}

		if (endAtLine == 0) 
		{
			endAtLine = textLines.Length - 1;
		}

		isTalking = true;
		useFader = true;
	}

	void Update()
	{
		if (currentLine <= endAtLine) 
		{
			if (useFader) 
			{
				theText.text = textLines [currentLine];				
			}

			if (!useFader) 
			{
				EnableDialogueBox ();
				DialogueText.text = textLines [currentLine];
			}
		}
				

		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			currentLine += 1;
		}

		if (currentLine > endAtLine && isTalking && !endOfStage) 
		{
			if (fader != null) 
			{
				fader.IsFaded = true;
			}

			if (eFader != null) 
			{
				eFader.IsFaded = true;
			}

			isTalking = false;



			if (DialogueBox != null)
			{
				DisableDialogueBox ();
			}
		}

		if (playerController != null) 
		{

			//Freezes Movement
			if (fader.IsFaded && DisableMovement || isTalking) {
				playerController.CanMove = false;
			}

			if (fader.IsFaded && !isTalking) {
				playerController.CanMove = true;
			}
		}


	}

	public void ReloadScript(TextAsset theText, bool stageEnd)
	{
		if (theText != null) 
		{
			isTalking = true;

			textLines = new string[1];
			textLines = (theText.text.Split ('\n'));


			endOfStage = stageEnd;

			if (endAtLine == 0) 
			{
				endAtLine = textLines.Length - 1;
			}
		}
	}

	public void FixEndLine()
	{
		endAtLine = textLines.Length - 1;
	}

	void EnableDialogueBox()
	{
		DialogueBox.SetActive (true);
	}

	void DisableDialogueBox()
	{
		DialogueBox.SetActive (false);
	}

}
