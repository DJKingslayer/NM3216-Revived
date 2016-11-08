using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BackupSceneEnd : MonoBehaviour {

	public GameObject CheckPresent;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (CheckPresent == null) 
		{
			SceneManager.LoadScene ("End");
		}
	}
}
