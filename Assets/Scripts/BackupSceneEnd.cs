using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BackupSceneEnd : MonoBehaviour {

	public GameObject CheckPresent;

	private SceneFader fader;

	// Use this for initialization
	void Start () 
	{
		fader = FindObjectOfType<SceneFader> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!CheckPresent.activeInHierarchy) 
		{
			Invoke("LoadFinalScene",3);		
		}
	}

	void LoadFinalScene()
	{
		SceneManager.LoadScene ("End");
	}
}
