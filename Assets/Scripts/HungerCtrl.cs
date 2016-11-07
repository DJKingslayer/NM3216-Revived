using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HungerCtrl : MonoBehaviour {

	private Image hungerBar;

	[SerializeField]
	private float currentHunger;
	public float TotalHunger;

	public bool GetHungry;

	private SceneFader fader;

	private PlayerController playerController;

	// Use this for initialization
	void Start () 
	{
		hungerBar = gameObject.GetComponent<Image> ();
		currentHunger = TotalHunger;

		fader = FindObjectOfType<SceneFader> ();

		playerController = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {

//		hungerBar.fillAmount = Mathf.Lerp (0f, 1f, (currentHunger / TotalHunger));
		hungerBar.fillAmount = Mathf.Lerp ((currentHunger / TotalHunger), hungerBar.fillAmount, -Time.deltaTime);

		if (GetHungry && fader.IsFaded) 
		{
			GetHungry = false;
			InvokeRepeating ("decreaseCurr", 1, 1);	
		}

		if (currentHunger == 0) 
		{
			playerController.HungerPang ();
		}
	
	}

	void decreaseCurr()
	{
		if (currentHunger > 0) 
		{
			currentHunger -= 1;
		}
	}

	public void EatBerry()
	{
		currentHunger = TotalHunger;
	}

}
