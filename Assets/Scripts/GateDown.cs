using UnityEngine;
using System.Collections;

public class GateDown : MonoBehaviour {

	private float startTime = 13f;

	// Update is called once per frame
	void Update () {
		float roundTime = Time.timeSinceLevelLoad;

		if(roundTime >= startTime && this.transform.position.y > -200f) {
			this.transform.position = this.transform.position - Vector3.up * Time.deltaTime * 2;
		}
	}
}
