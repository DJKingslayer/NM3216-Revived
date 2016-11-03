﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour {

	public Text fadeScreenText;
	public Text NextKey;

	public bool IsFaded;

	private SpriteRenderer cover;

	[SerializeField]
	private Color faded;

	[SerializeField]
	private int fadeTime;

	private Color offBlack;

	private GameObject crosshair;

	[SerializeField]
	private PlayerController playerController;

	private TextBoxManager textBoxManager;

	[SerializeField]
	private bool isTest;

	private string NextScene;

	// Use this for initialization
	void Start () 
	{		
		cover = GameObject.Find ("Cover").GetComponent<SpriteRenderer>();
		playerController = FindObjectOfType<PlayerController> ();
		textBoxManager = FindObjectOfType<TextBoxManager> ();

		cover.color = Color.black;

		offBlack = Color.black;
		offBlack.a = .8f;

		if (NextKey == null) 
		{
			NextKey = GameObject.Find ("NextKey").GetComponent<Text>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		if (IsFaded) 
		{
			FadeToWhite ();
		}

		if (!IsFaded) 
		{
			FadeToBlack ();
		}


		if (!playerController.isAlive) 
		{
			IsFaded = false;
			fadeScreenText.text = "You Lose press R to respawn from Checkpoint. \n Continues left: " 
				+ playerController.Lives.ToString() ;

			if (playerController.Lives <= 0) 
			{
				fadeScreenText.text = "Game Over. Press Space to return to Menu";

				if (Input.GetKeyDown (KeyCode.Space)) 
				{
					SceneManager.LoadScene ("Menu");
				}
			}
		}

		if (textBoxManager.endOfStage && textBoxManager.currentLine > textBoxManager.endAtLine) 
		{						
			sceneSelect ();
			SceneManager.LoadScene (NextScene);
			PlayerData.Scene += 1;			

		}

		if (!playerController.isAlive) 
		{
			if (playerController.Lives > 0) 
			{
				NextKey.text = "Press R";
			}

			if (playerController.Lives == 0) 
			{
				NextKey.text = "Press M";
			}

		} else
			NextKey.text = "Press Space";
	}

	void FadeToWhite()
	{
		cover.color = Color.Lerp (cover.color, faded, Time.deltaTime * fadeTime);
		fadeScreenText.color = Color.Lerp (fadeScreenText.color, faded, Time.deltaTime * fadeTime);
		NextKey.color = Color.Lerp (fadeScreenText.color, Color.white, Time.deltaTime * fadeTime);

	}

	void FadeToBlack ()
	{
		if (playerController.isAlive) {
			cover.color = Color.Lerp (cover.color, Color.black, Time.deltaTime * fadeTime);
			fadeScreenText.color = Color.Lerp (fadeScreenText.color, Color.white, Time.deltaTime * fadeTime);
			NextKey.color = Color.Lerp (fadeScreenText.color, Color.white, Time.deltaTime * fadeTime);

		} 

		else cover.color = Color.Lerp (cover.color, offBlack, Time.deltaTime * fadeTime);
		fadeScreenText.color = Color.Lerp (fadeScreenText.color, Color.white, Time.deltaTime * fadeTime);
		NextKey.color = Color.Lerp (fadeScreenText.color, Color.white, Time.deltaTime * fadeTime);
	}

	void sceneSelect()
	{
		Scene CurrentScene = SceneManager.GetActiveScene ();

		if (CurrentScene.name == "Tutorial_Learning_Portion") 
		{
			NextScene = "Tutorial_Calculation_Portion";
		}

		if (CurrentScene.name == "Tutorial_Calculation_Portion") 
		{
			if (PlayerData.IsKiller) 
			{
				NextScene = "FenrirMain";
			}

			if (!PlayerData.IsKiller) 
			{
				NextScene = "IriMain";
			}
		}				
	}
}

