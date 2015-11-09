using UnityEngine;
using System.Collections;

public class BonusItemCollision : MonoBehaviour
{
  private GameObject playerGameObject;
  private Done_PlayerController playerController;
	// Use this for initialization
	void Start () {
	  playerGameObject = GameObject.FindWithTag("Player");
	  playerController = playerGameObject.GetComponent<Done_PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

  private void OnTriggerEnter(Collider other)
  {
    if (other.tag == "Player")
    {
      playerController.SpeedUpFire(0.1f);
      Destroy(gameObject);
    }
  }
}
