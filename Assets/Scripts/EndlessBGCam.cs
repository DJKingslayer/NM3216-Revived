using UnityEngine;
using System.Collections;

public class EndlessBGCam : MonoBehaviour {

	private EndlessRunnerPlayer endlessPlayer; 

	// Use this for initialization
	void Start () {
		endlessPlayer = FindObjectOfType<EndlessRunnerPlayer> ();
	}

	// Update is called once per frame
	void LateUpdate () 
	{
		Vector3 temp =	new Vector3 ( transform.position.x,(.2f * endlessPlayer.transform.position.y) + 121 ,transform.position.z);
		temp.y = Mathf.Clamp (temp.y, 121, 125);
		transform.position = temp;	
	}
}
