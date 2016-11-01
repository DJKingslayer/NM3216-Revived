using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HungerCtrl : MonoBehaviour {

	private Image hungerBar;

	[SerializeField]
	private float currentHunger;
	public float TotalHunger;

	// Use this for initialization
	void Start () 
	{
		hungerBar = gameObject.GetComponent<Image> ();
		currentHunger = TotalHunger;
		InvokeRepeating ("decreaseCurr", 1, 1);	
	}
	
	// Update is called once per frame
	void Update () {

//		hungerBar.fillAmount = Mathf.Lerp (0f, 1f, (currentHunger / TotalHunger));
		hungerBar.fillAmount = Mathf.Lerp ((currentHunger / TotalHunger), hungerBar.fillAmount, -Time.deltaTime);

	
	}

	void decreaseCurr()
	{
		currentHunger -= 1;
	}

	public void EatBerry()
	{
		currentHunger = TotalHunger;
	}
}
