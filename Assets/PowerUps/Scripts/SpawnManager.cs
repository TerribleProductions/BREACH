using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

public class SpawnManager : MonoBehaviour {
	public GameObject needle;
	public float timer;
	public float timeTaken = 0;
	Vector3 pos;



	GameObject player1;
	GameObject player2;

	// Use this for initialization
	void Start () {
		needle = GameObject.Find("Needle");
		pos = needle.transform.position;

		player1 = GameObject.Find("Player");
		player2 = GameObject.Find("Player 2");
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
	

		//Time to respawn power up
		if((timer - timeTaken) > 2 && timeTaken != 0){
			timeTaken = 0;
			needle = Instantiate(Resources.Load ("Needle")) as GameObject;
			needle.transform.parent = transform;
			needle.transform.position = pos;
		}
	}

	public void deactivate(){
		Destroy (needle);
	}
}
