using UnityEngine;
using System.Collections;

public class Done_DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
	private Done_GameController gameController;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <Done_GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Boundary" || other.tag == "Enemy" || other.tag == "BonusItem")
		{
			return;
		}

		if (explosion != null)
		{
			Instantiate(explosion, transform.position, transform.rotation);
		}

		GameObject hittedObject = null;
		GameObject damager = null;
		Damage damage = null;
		Hitpoint hitpoint = null;

		IList gos = new ArrayList ();


		damage = gameObject.GetComponent<Damage>();
		if (damage != null) {
			hittedObject = other.gameObject;
			damager = gameObject;
			gos.Add(damager);
		} 

		if(hittedObject != null && hittedObject.GetComponent<Hitpoint>() != null && damager !=null) // one of them is bolt
		{
			hitpoint = hittedObject.GetComponent<Hitpoint>();
			damage = damager.GetComponent<Damage>();
			hitpoint.ReducePoint(damage.Value);
		}

		damage = null;
		hittedObject = null;
		damage = other.gameObject.GetComponent<Damage>();
		if (damage != null) {
			hittedObject = gameObject;
			damager = other.gameObject;
			gos.Add(damager);
		} 
		
		if(hittedObject != null && hittedObject.GetComponent<Hitpoint>() != null && damager !=null) // one of them is bolt
		{
			hitpoint = hittedObject.GetComponent<Hitpoint>();
			damage = damager.GetComponent<Damage>();
			hitpoint.ReducePoint(damage.Value);
		}


		if (gos.Count == 0 && ((tag == "Enemy" && other.tag == "Player") ||(other.tag == "Enemy" && tag == "Player")))
		{
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			Destroy (other.gameObject);
			Destroy (gameObject);
			gameController.GameOver();
		}

		foreach (GameObject go in gos) {
			Destroy (go);
		}


		/*
		gameController.AddScore(scoreValue);
		Destroy (other.gameObject);
		Destroy (gameObject);
		*/

	}
}