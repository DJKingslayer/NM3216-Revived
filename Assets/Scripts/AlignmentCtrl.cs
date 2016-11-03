using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AlignmentCtrl : MonoBehaviour {
	
	public TextAsset WhiteText, BlackText;

	private TextBoxManager textBoxManager;

	[SerializeField]
	private float alignCost;

	void Start()
	{
		textBoxManager = FindObjectOfType<TextBoxManager> ();
	}

	void Update ()
	{	
	}
	

	public void SetAlign()
	{
		if (PlayerData.KillCount > alignCost) 
		{
			PlayerData.IsKiller = true;
		}

		PlayerData.AlignSet = true;
	}

}
