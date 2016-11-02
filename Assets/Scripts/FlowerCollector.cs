using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FlowerCollector : MonoBehaviour {

	private int flowersCollected;

	private Text flowerText;

	// Use this for initialization
	void Start () 
	{
		flowerText = GameObject.Find ("Flowers Collected").GetComponent<Text>();
		flowersCollected = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		flowerText.text = "Flowers: " + flowersCollected.ToString () + "/6";
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Flowers")) 
		{
			other.gameObject.SetActive (false);
			flowersCollected += 1;
		}
	}
}
