using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class godmode : MonoBehaviour 
{
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Q)) 
		{
			PlayerData.godMode = true;
			SceneManager.LoadScene ("Tutorial_Learning_Portion");
			print ("godMode Activated");
		}
	}
}
