using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {

	public GameObject platform;
	public Transform generationPoint;
	public float dist;
	public float distMin;
	public float distMax;

	private float platformWidth;

	public GameObject[] platforms;
	private int platformSelector;

	private float[] platformWidths;

	private float minHeight;
	public Transform maxHeightPoint;
	private float maxHeight; 
	public float maxHeightChange;
	private float heightChange;
	private EndlessRunnerPlayer endlessPlayer;
	private Vector3 startPos;
	//public ObjectPooler[] objectPools; 

	// Use this for initialization
	void Start () {
		endlessPlayer = GameObject.Find("Player").GetComponent<EndlessRunnerPlayer> ();
		//platformWidth = platform.GetComponent<BoxCollider2D>().size.x;
		platformWidths = new float[platforms.Length];

		for (int i = 0; i < platforms.Length; i++) 
		{
			platformWidths [i] = platforms[i].GetComponent<BoxCollider2D> ().size.x;
		}

		minHeight = transform.position.y;
		maxHeight = maxHeightPoint.position.y;

	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < generationPoint.position.x) {

			dist = Random.Range (distMin, distMax);

			platformSelector = Random.Range(0, platforms.Length);

			heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

			if (heightChange > maxHeight) {
				heightChange = maxHeight;
			} else if (heightChange < minHeight) 
			{
				heightChange = minHeight;
			}

			if (endlessPlayer.isAlive==false) 
			{
				if (endlessPlayer.isAlive == true) 
				{
					transform.position = startPos;
				}
			}

			transform.position = new Vector3 (transform.position.x + (platformWidths[platformSelector]) + dist, heightChange, transform.position.z);

			Instantiate (platforms[platformSelector], transform.position, transform.rotation);


			/*GameObject newPlatform = objectPools[platformSelector].GetPooledObject();

			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive (true); */

			//transform.position = new Vector3 (transform.position.x + (platformWidths[platformSelector] / 2), heightChange, transform.position.z);
		}
	}
}
