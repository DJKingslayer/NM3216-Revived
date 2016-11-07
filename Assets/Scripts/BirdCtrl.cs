using UnityEngine;
using System.Collections;

public class BirdCtrl : MonoBehaviour {

	public float Speed;

	public bool Respawns;

	public GameObject Bird;

	private SfxCtrl sfx;

	private Rigidbody2D rb;

	private Vector3 originalPos;

	private SceneFader scene;

	public float RespawnTimer;
	public float DeathTimer;

	void Awake()
	{
		originalPos = gameObject.transform.position;
	}

	// Use this for initialization
	void Start () {

		scene = FindObjectOfType<SceneFader> ();
	
		rb = gameObject.GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector2(-Speed,0);

		float spawnRan = Random.Range (5f, 7f);

		sfx = FindObjectOfType<SfxCtrl>();

		if (RespawnTimer == 0) 
		{
			RespawnTimer = spawnRan;
		}

		if (DeathTimer == 0) 
		{
			DeathTimer = 10;
		}

		if (Respawns) 
		{
			Invoke ("Respawn", RespawnTimer);
			Destroy (gameObject, DeathTimer);
		}

		if (!Respawns) 
		{
			InvokeRepeating ("turn", DeathTimer, DeathTimer);
		}

	}

	void Update(){

		if (scene.IsFaded) {
			
			rb.velocity = new Vector2 (-Speed, 0);
		} else rb.velocity = new Vector2 (0, 0);

	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.CompareTag("Wall"))
		{
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		
		if (other.CompareTag ("Destroyer")) {
			sfx.PlaySfx (sfx.BirdDeath);
			Destroy (gameObject);	
		}


	}

	void Respawn ()
	{
		Instantiate (Bird,originalPos,Quaternion.identity);
	}

	void turn()
	{
		Vector3 temp = gameObject.transform.localScale;
		temp.x *= -1;
		transform.localScale = temp;

		Vector2 tempVelocity = rb.velocity;
		tempVelocity *= -1;
		rb.velocity = tempVelocity;
	}


}
