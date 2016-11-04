using UnityEngine;
using System.Collections;

public class ButtonActivator : MonoBehaviour 
{

	public GameObject ToActivate;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name =="Player") 
		{
			ToActivate.SetActive (true);
		}
	}
}
