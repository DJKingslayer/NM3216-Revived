using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndFader : MonoBehaviour {

	private SpriteRenderer cover;

	private Text fadeScreenText;
	private Text NextKey;

	public float fadeTime;

	[SerializeField]
	private Color faded;

	public bool IsFaded;

	// Use this for initialization
	void Start () 
	{
		cover = gameObject.GetComponent<SpriteRenderer> ();
		fadeScreenText = GameObject.Find ("FadescreenText").GetComponent<Text> ();
		NextKey = GameObject.Find ("NextKey").GetComponent<Text> ();

		faded = cover.color;
		faded.a = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (IsFaded || Input.GetKeyDown(KeyCode.P)) 
		{
			FadeToWhite ();
		}
	}

	void FadeToWhite()
	{
		cover.color = Color.Lerp (cover.color, faded, Time.deltaTime * fadeTime);
		fadeScreenText.color = Color.Lerp (fadeScreenText.color, faded, Time.deltaTime * fadeTime);
		NextKey.color = Color.Lerp (fadeScreenText.color, Color.white, Time.deltaTime * fadeTime);

//		cover.color = faded;
	}
}
