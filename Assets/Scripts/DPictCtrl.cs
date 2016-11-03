using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DPictCtrl : MonoBehaviour {

	public Sprite SpriteToLoad;

	private Image DPic;

	// Use this for initialization
	void Start () 
	{
		DPic = GameObject.Find ("Dialogue Picture").GetComponent<Image>();	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (SpriteToLoad != null && other.name == "Player") 
		{
			DPic.sprite = SpriteToLoad;
		}
	}
}
