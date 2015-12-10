using UnityEngine;
using System.Collections;

public class GateDown : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		float roundTime = Time.timeSinceLevelLoad;

		if(roundTime >= 15f) {
			this.transform.position = this.transform.position - Vector3.up * 200f;
		}
	}
}
