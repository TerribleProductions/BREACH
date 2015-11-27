using UnityEngine;
using System.Collections;

public class PlayerShine : MonoBehaviour {

	public GameObject player = null;
	public Camera camera;

	void Update () {

		// Transforms the texture from world space to screen space
		Vector3 newPosition = camera.WorldToViewportPoint (player.transform.position);

		newPosition.y += 0.02f;
		this.transform.position = newPosition;
	}
}
