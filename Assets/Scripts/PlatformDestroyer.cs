using UnityEngine;
using System.Collections;

public class PlatformDestroyer : MonoBehaviour {

	public GameObject platformDestructionPoint;

	public bool Important;

	// Use this for initialization
	void Start () {
		platformDestructionPoint = GameObject.Find ("Platform Destruction Point");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (transform.position.x < platformDestructionPoint.transform.position.x && !Important) {
			Destroy (gameObject);
			//gameObject.SetActive(false);
		}
	}
}
