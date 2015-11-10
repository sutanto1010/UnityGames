using UnityEngine;
using System.Collections;

[System.Serializable]
public class Done_Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class Done_PlayerController : MonoBehaviour
{
	public float speed;
	public float tilt;
	public Done_Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	private Rigidbody playerRigidbody;

	private float nextFire;

	void Start(){
		playerRigidbody = GetComponent<Rigidbody>();
	}
	void Update ()
	{
		if (Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			GetComponent<AudioSource>().Play ();
		}
	}

	public void MovePlayer(float x, float y, float z)
	{
		Vector3 movement = new Vector3(x, y, z);
		playerRigidbody.velocity = movement * speed;
    }

	public void StopMovement()
	{
		playerRigidbody.velocity = playerRigidbody.position * 0;
	}


	public void SpeedUpFire(float speedUpTime)
	{
		if (fireRate >= 0.2f)
			fireRate -= speedUpTime;
		Done_Mover shotMover = shot.GetComponent<Done_Mover> ();
		shotMover.speed = shotMover.speed + 2;
	}



	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody>().velocity = movement * speed;
		
		GetComponent<Rigidbody>().position = new Vector3
		(
			Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
		);
		
		GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}

  
	
}
