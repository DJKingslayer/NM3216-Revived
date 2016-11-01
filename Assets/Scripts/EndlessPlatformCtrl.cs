using UnityEngine;
using System.Collections;

public class EndlessPlatformCtrl : MonoBehaviour {

	//	private Rigidbody2D playerBody;

	private BoxCollider2D playerCollider;
	private BoxCollider2D platformCollider;
	private EndlessRunnerPlayer endlessPlayer;

	private GameObject player;

	//	private bool isLanded;
	private bool abovePlayer;


	// Use this for initialization
	void Start () {
		//		playerBody = GameObject.Find ("Player").GetComponent<
		player = GameObject.Find("Player");

		//access colliders
		playerCollider = player.GetComponent<BoxCollider2D>();
		platformCollider = gameObject.GetComponent<BoxCollider2D> ();

		endlessPlayer = player.GetComponent<EndlessRunnerPlayer> ();

	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		if (player.transform.position.y < gameObject.transform.position.y) {
			abovePlayer = true;
		} else abovePlayer = false;

		if (endlessPlayer.jumping || abovePlayer )
		{
			Physics2D.IgnoreCollision (playerCollider, platformCollider, true);

		}

		if (!endlessPlayer.jumping && !abovePlayer || !endlessPlayer.isPouncing && !abovePlayer
			|| !abovePlayer)
		{
			Physics2D.IgnoreCollision (playerCollider, platformCollider, false);
		}

	}

}
