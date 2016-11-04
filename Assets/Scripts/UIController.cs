using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

	public Text lives;

	public Image Pounce, Phase, Bite, Leap;

	[SerializeField]
	private PlayerController playerController;

	
	// Update is called once per frame
	void Update () 
	{

		playerController = FindObjectOfType<PlayerController> ();
		lives.text = "Lives :" + playerController.Lives.ToString();

		if (playerController.Fenrir) {
			Pounce.fillAmount = Mathf.Lerp (0, 1, playerController.PounceCD / playerController.PounceCoolDown);
			Bite.fillAmount = Mathf.Lerp (0, 1, playerController.PounceCD / 1f);
		}

		if (playerController.Iri) {
			Phase.fillAmount = Mathf.Lerp (0, 1, playerController.PounceCD / 4f);
			Leap.fillAmount = Mathf.Lerp (0, 1, playerController.PounceCD / 2f);
		}
	}

	public void LoadScene(string SceneName)
	{
		SceneManager.LoadScene(SceneName);
	}


}
