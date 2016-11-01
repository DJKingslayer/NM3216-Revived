using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndlessHPController : MonoBehaviour {
	
	private EndlessRunnerPlayer endlessPlayer;
	private Image HPBar;
	private Text HPText;
	private Image PounceBar;
	private Text PounceText;

	[SerializeField]
	private float fillAmount;

	private float pounceFA;

	void Awake(){

	}

	// Use this for initialization
	void Start () {
		HPBar = GameObject.Find ("Hp Bar").GetComponent<Image> ();

		PounceBar = GameObject.Find ("Pounce Bar").GetComponent<Image> ();

		endlessPlayer = GameObject.Find ("Player").GetComponent<EndlessRunnerPlayer>();
	}

	// Update is called once per frame
	void Update () {
		fillAmount = Map (endlessPlayer.HPCurrent,endlessPlayer.HPMax);
		pounceFA = Map (endlessPlayer.PounceCD, endlessPlayer.PounceCoolDown);

		handleBar ();	
		handlePBar ();
	}

	private void handleBar()
	{
		if (fillAmount != HPBar.fillAmount) {	
			HPBar.fillAmount = Mathf.Lerp (HPBar.fillAmount, fillAmount, Time.deltaTime * .5f);
		} 
	}

	private float Map (float Current,float Max)
	{
		return (Current / Max);
	}

	private void handlePBar()
	{
		if (PounceBar.fillAmount != pounceFA) {

			PounceBar.fillAmount = Mathf.Lerp (PounceBar.fillAmount, pounceFA, Time.deltaTime * .5f);

			int CoolDown = endlessPlayer.PounceCoolDown - endlessPlayer.PounceCD;
	
		}
	}

	private string display (float min, float max)
	{
		return min.ToString () + "/" + max.ToString();
	}
}
