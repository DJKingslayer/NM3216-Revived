using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CollectionCtrl : MonoBehaviour {

	public string TypeOfItem;

	public int TotalNumberOfItems;

	private int ItemCollected;

	private Text itemText;

	// Use this for initialization
	void Start () 
	{
		itemText = GameObject.Find ("Collectible").GetComponent<Text>();
		ItemCollected = 0;
	}

	// Update is called once per frame
	void Update () 
	{
		itemText.text = TypeOfItem.ToString()+ ": "+ ItemCollected.ToString () + "/"+TotalNumberOfItems.ToString();

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Collectible")) 
		{
			other.gameObject.SetActive (false);
			ItemCollected += 1;
		}
	}
}
