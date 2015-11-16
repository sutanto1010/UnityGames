using UnityEngine;
using System.Collections;

public class Done_Mover : MonoBehaviour
{
	public float speedZ;
	public float speedX;

	void Start ()
	{
		GetComponent<Rigidbody>().velocity = transform.right * speedX + transform.forward * speedZ;
	}

	public void UpdateSpeed(Vector3 newSpeed){
		GetComponent<Rigidbody>().velocity = newSpeed * speedX;
		var position = GetComponent<Rigidbody> ().position;
		if (position.y != 0) 
		{
			position.y = 0;
			GetComponent<Rigidbody> ().position = position;
		}

	}
}
