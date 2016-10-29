using UnityEngine;
using System.Collections;

public class AISpawner : MonoBehaviour {

	public GameObject Crosshair;
//	public float BirdHt, BirdSpawnRate;
	private SceneFader scene;

	private Transform player;

	// Use this for initialization
	void Start () {
		scene = FindObjectOfType<SceneFader> ();

//		player = GameObject.Find ("Player").GetComponent<Transform> ();
//		InvokeRepeating ("SBird", BirdSpawnRate, BirdSpawnRate);
	}
	
	// Update is called once per frame
	void Update () {

		if (Crosshair != null) {

			if (scene.IsFaded) {
				Crosshair.SetActive (true);
			}

			if (!scene.IsFaded) {
				Crosshair.SetActive (false);
			}
		}
	}

//	void SBird()
//	{
//		Vector3 BirdPos = new Vector3 (player.transform.position.x + 10, BirdHt);
//		Instantiate (Bird, BirdPos, Quaternion.identity);
//	}
}
