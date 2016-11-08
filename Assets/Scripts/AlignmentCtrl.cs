using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AlignmentCtrl : MonoBehaviour {
	
	public TextAsset WhiteText, BlackText;

	public float alignCost;

	void Start()
	{
		if (alignCost == 0) 
		{
			alignCost = 7;
		}
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
