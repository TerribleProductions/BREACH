using UnityEngine;
using System.Collections;

public class KeyboardInterface : MonoBehaviour {

	private int playerNumber = 1;
	private string playerId;

	public KeyboardInterface(int playerNumber) {
		this.playerNumber = playerNumber;

		playerId = "player " + playerNumber;
	}

	public float getMovementHorizontal() {
		return Input.GetAxis (playerId + " horizontal move");
	}

	public float getMovementVertical() {
		return Input.GetAxis (playerId + " vertical move");
	}

	public float getLookHorizontal() {
		return Input.GetAxis (playerId + " horizontal look");
	}
	
	public float getLookVertical() {
		return Input.GetAxis (playerId + " vertical look");
	}

	public bool getFire() {
		return Input.GetButton(playerId + " fire");
	}
}
