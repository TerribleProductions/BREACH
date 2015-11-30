using UnityEngine;
using System.Collections;

public class PowerUpSpeed : MonoBehaviour {
	public GameObject needle;

	GameObject needleParent;
	GameObject player; 
	GameObject player2; 
	Slow powerupspeed;

	void Awake(){
		needleParent = GameObject.Find("NeedleParent");
		powerupspeed = new Slow (2f, 3, false, "powerupspeed");
	}
	

	void OnTriggerEnter(Collider other) {
		var character = other.gameObject.GetComponent<Character>();
		if (character != null) {

			character.AddBuff (powerupspeed);
			needleParent.GetComponent <SpawnManager> ().timeTaken = needleParent.GetComponent <SpawnManager> ().timer;
			needleParent.GetComponent <SpawnManager> ().deactivate (); 

		} 
	}
}
