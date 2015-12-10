using UnityEngine;
using System.Collections;

public class StunVisual : MonoBehaviour {
	
	// Update is called once per frame
	void FixedUpdate () {

		if (Camera.current != null) {
			Vector3 cameraPos = Camera.current.transform.position;

			this.transform.RotateAround (this.transform.position, this.transform.forward, 200f * Time.deltaTime);
		}
	}
}
