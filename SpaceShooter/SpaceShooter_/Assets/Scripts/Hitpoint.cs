using UnityEngine;
using System.Collections;

public class Hitpoint : MonoBehaviour {

	public int Health;
	public int scoreValue;
	public int maxBonusAmount;
	public int maxAsteroidAmount;

	public GameObject explosion;


	public GameObject[] hazards;

	public GameObject[] bonuses;
	public int bonusProbability;

	private Done_GameController gameController;

	void Start(){
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <Done_GameController> ();
		}
		if (gameController == null) {
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	public void ReducePoint(int damage){
		Health = Health - damage;
		if(gameObject.tag == "Player"){
			gameController.UpdateHealth(Health);
		}
		if (Health <= 0) {
			Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
			Destroy(gameObject);
			InstantiateHazard();

			if(gameObject.tag == "Player"){
				gameController.GameOver();
			}else{
				gameController.AddScore(scoreValue);
			}

		}
	}

	void InstantiateHazard(){
		for( int i = 0 ; i < maxAsteroidAmount; i++) {
			var hazard = hazards[Random.Range(0, hazards.Length)];
			int degree = Random.Range (1, 360);
			//Debug.Log( "Degree: "+ degree);
			float rad = Mathf.Deg2Rad * degree;
			float relativeX = Mathf.Sin (rad);
			float relativeZ = Mathf.Cos (rad);
			var moverSpeed = hazard.GetComponent<Done_Mover>();
			var moverSpeedX = moverSpeed.speedX;
			var moverSpeedZ = moverSpeed.speedZ;
			moverSpeed.speedX = -relativeX * gameObject.GetComponent<Done_Mover>().speedZ;
			moverSpeed.speedZ = -relativeZ * gameObject.GetComponent<Done_Mover>().speedZ;
			//Debug.Log( "X: "+ moverSpeed.speedX + " Z: " + moverSpeed.speedZ);
			Instantiate(hazard, gameObject.transform.position + new Vector3(relativeX * 1f, 0f, relativeZ * 1f ), Quaternion.identity);
			moverSpeed.speedX = moverSpeedX;
			moverSpeed.speedZ = moverSpeedZ;
		}

		for( int i = 0 ; i < maxBonusAmount; i++) {
			int throwDice = Random.Range (0, 100);
			if (throwDice < bonusProbability) {
				var bonus = bonuses[Random.Range(0, bonuses.Length)];
				int degree = Random.Range (1, 360);
				//Debug.Log( "Degree: "+ degree);
				float rad = Mathf.Deg2Rad * degree;
				float relativeX = Mathf.Sin (rad);
				float relativeZ = Mathf.Cos (rad);
				var moverSpeed = bonus.GetComponent<Done_Mover>();
				var moverSpeedX = moverSpeed.speedX;
				var moverSpeedZ = moverSpeed.speedZ;
				moverSpeed.speedX = -relativeX * gameObject.GetComponent<Done_Mover>().speedZ;
				moverSpeed.speedZ = -relativeZ * gameObject.GetComponent<Done_Mover>().speedZ;
				//Debug.Log( "X: "+ moverSpeed.speedX + " Z: " + moverSpeed.speedZ);
				Instantiate(bonus, gameObject.transform.position + new Vector3(relativeX * 1f, 0f, relativeZ * 1f ), Quaternion.identity);
				moverSpeed.speedX = moverSpeedX;
				moverSpeed.speedZ = moverSpeedZ;
			}
		}
	}
}
