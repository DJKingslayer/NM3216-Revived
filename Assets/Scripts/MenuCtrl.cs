using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuCtrl: MonoBehaviour 
{
	void Start()
	{
		
	}

	public void LoadScene(string SceneName)
	{
		SceneManager.LoadScene (SceneName);
	}

	void FixedUpdate()
	{
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			SceneManager.LoadScene ("Tutorial");
		}
	}

}
	