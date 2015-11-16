using UnityEngine;
using System.Collections;

public class InstantiateOnDestroy : MonoBehaviour {

	public GameObject[] hazards;
	public GameObject[] bonuses;
	public Done_Boundary boundary;

	/*
	public void OnDestroy()
	{
		int i = 0;
		foreach (GameObject hazard in hazards) {
			i++;
			Vector3 newPosition = transform.position + new Vector3 (i,0,1);
			GameObject clone = (GameObject) Instantiate(hazard, newPosition, transform.rotation);
			Debug.Log("Clone previous velocity " + clone.GetComponent<Rigidbody>().velocity );

			clone.GetComponent<Rigidbody>().velocity = Vector3.zero;
			Done_Mover d = clone.GetComponent<Done_Mover>();
			//d.UpdateSpeed(new Vector3 (4, 0.0f, -4));

			clone.GetComponent<Rigidbody>().position = new Vector3
				(
					Mathf.Clamp(transform.position.x, boundary.xMin, boundary.xMax), 
					0.0f, 
					Mathf.Clamp(transform.position.z, boundary.zMin, boundary.zMax)
					);
			
			clone.GetComponent<Rigidbody>().rotation = Quaternion.Euler (0, 0, GetComponent<Rigidbody>().velocity.x * Random.Range(1,5));
			//clone.GetComponent<Rigidbody>().velocity = new Vector3 (4, 0.0f, -4);
			//clone.GetComponent<Rigidbody>().velocity = ( transform.forward + transform.right ) * clone.GetComponent<Done_Mover>().speed;
			Debug.Log("clone velocity " + clone.GetComponent<Rigidbody>().velocity );
			//clone.GetComponent<Rigidbody>().velocity = transform.right * ((Random.Range(0,2)%2)*-1)*5;
		}

	}
		*/


}
