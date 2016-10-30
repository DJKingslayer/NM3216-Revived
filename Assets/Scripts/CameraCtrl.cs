using UnityEngine;
using System.Collections;

public class CameraCtrl : MonoBehaviour 
{
	public Transform player;
	public float MaxY,MinY;

	public bool StaticCam;

	Vector3 offset;
//	private float camY;

	void Start()
	{
		offset = transform.position - player.position;	
//		camY = 1.51f;		

		if (MaxY == 0) 
		{
			MaxY = 6;
		}
	}
		
	void LateUpdate () 	
	{	


		if (StaticCam) 
		{
			transform.position = new Vector3 (player.position.x , MinY, transform.position.z);

			if ((player.position.y - transform.position.y) > 2) 
			{
				float yDiff = player.position.y - transform.position.y - 2;
				transform.position = new Vector3 (player.position.x , MinY + yDiff, transform.position.z);

			}
			return;
		}

		Vector3 temp = new Vector3 (player.position.x, player.position.y + offset.y + 1, transform.position.z);
		temp.y = Mathf.Clamp (temp.y, MinY , MaxY);
		transform.position = temp;
	}
}