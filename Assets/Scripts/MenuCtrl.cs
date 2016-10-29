using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuCtrl: MonoBehaviour 
{
	private string DelayScene;

	private SfxCtrl sfx;

	void Start()
	{
		DelayScene = null;	
		sfx = FindObjectOfType<SfxCtrl> ();
	}

	public void LoadScene(string SceneName)
	{	
		if (DelayScene != null) 
		{
			SceneName = DelayScene;
		}

		SceneManager.LoadScene (SceneName);
		
	}

	void FixedUpdate()
	{
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			sfx.PlaySfx (sfx.SadHowl);
			Invoke ("LoadTutorial", 5);
		}
	}

	public void DelayLoad()
	{
		Invoke ("LoadTutorial", 5);
	}

	void LoadTutorial()
	{
		SceneManager.LoadScene ("Tutorial_Learning_Portion");
	}
}
	