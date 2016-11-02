using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndlessUIController : MonoBehaviour {

	public Text lives;

	[SerializeField]
	private EndlessRunnerPlayer endlessPlayer;


	// Update is called once per frame
	void Update () {

		endlessPlayer = FindObjectOfType<EndlessRunnerPlayer> ();
		lives.text = "Lives :" + endlessPlayer.Lives.ToString();	
	}

	public void LoadScene(string SceneName)
	{
		//		PlayerData.IsKiller = false;
		//		PlayerData.AlignSet = false;
		SceneManager.LoadScene(SceneName);
	}


}
