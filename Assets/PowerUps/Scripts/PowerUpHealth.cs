using UnityEngine;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PowerUpHealth : MonoBehaviour {

	GameObject firstAidParent;
	GameObject player; 
	GameObject player2;

	public Slider healthSlider;
	
	void Start(){
		firstAidParent = GameObject.Find("FirstAidParent");
		healthSlider = GameObject.Find ("HealthSlider").GetComponent <Slider> ();
	}

	void OnTriggerEnter(Collider other) {
		var character = other.gameObject.GetComponent<Character>();
		if (character != null) {
			character.DamageCharacter(-20f);
			firstAidParent.GetComponent <SpawnManagerFirstAid> ().timeTaken = firstAidParent.GetComponent <SpawnManagerFirstAid> ().timer;
			firstAidParent.GetComponent <SpawnManagerFirstAid> ().deactivate ();

		} 
	}	
}
