using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

public class SpawnManagerFirstAid : MonoBehaviour {
	public GameObject firstAid;
	public float timer;
	public float timeTaken = 0;
	Vector3 pos;
	
	GameObject player1;
	GameObject player2;
	
	// Use this for initialization
	void Start () {
		firstAid = GameObject.Find("FirstAid");
		pos = firstAid.transform.position;
		
		player1 = GameObject.Find("Player");
		player2 = GameObject.Find("Player 2");
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		
		//Time to respawn power up
		if((timer - timeTaken) > 5 && timeTaken != 0){
			timeTaken = 0;
			firstAid = Instantiate(Resources.Load ("FirstAid")) as GameObject;
			firstAid.transform.parent = transform;
			firstAid.transform.position = pos;
			firstAid.transform.rotation = Quaternion.Euler(90, 0, 0);
		}
	}
	
	public void deactivate(){
		Destroy (firstAid);
	}
}

