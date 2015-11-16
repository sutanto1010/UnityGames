using UnityEngine;
using System.Collections;

public class Done_GameController : MonoBehaviour
{
	public GameObject[] hazards;
	public GameObject[] bonuses;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public float bonusSpawnTime;//second
	public float nextBonusSpawnTime;//second
	
	public GUIText scoreText;
	public GUIText gameOverText;
	public GUIText healthText;

	public GameObject panelGameOver;

	private bool gameOver;
	private bool restart;
	private int score;
	
	void Start ()
	{
		gameOver = false;
		restart = false;
		gameOverText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
		panelGameOver.SetActive (false);
		nextBonusSpawnTime = Time.time + bonusSpawnTime;

		int health = 0;
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		Hitpoint hp = player.GetComponent<Hitpoint> ();
		UpdateHealth (hp.Health);
	}
	
	void Update ()
	{
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)) {
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}
	
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true) {
			if (Time.time > nextBonusSpawnTime) {
				var bonusRandom = bonuses [Random.Range (0, bonuses.Length)];
				Vector3 bonusSpawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Instantiate (bonusRandom, bonusSpawnPosition, Quaternion.identity);
				nextBonusSpawnTime = Time.time + bonusSpawnTime;
			}

			for (int i = 0; i < hazardCount; i++) {
				GameObject hazard = hazards [Random.Range (0, hazards.Length)];
				Vector3 enemySpawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, enemySpawnPosition, spawnRotation);

				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			
			if (gameOver) {
				restart = true;
				break;
			}
		}
	}
	
	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}
	
	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}
	
	public void UpdateHealth (int health)
	{
		string healthString = string.Empty;
		for (int i = 0; i < health; i++) {
			healthString += "I";
		}
		healthText.text = healthString;
	}
	
	public void GameOver ()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
		panelGameOver.SetActive (true);
	}
}