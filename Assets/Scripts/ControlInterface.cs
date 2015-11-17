using UnityEngine;
using System.Collections;

public class ControlInterface : MonoBehaviour {

	private int playerNumber = 1;
	private GamepadInterface gamepadInterface;
	private KeyboardInterface keyboardInterface;

	private float epsilon = 0.001f;

	public ControlInterface(int playerNumber){
		this.playerNumber = playerNumber;
		gamepadInterface = new GamepadInterface (playerNumber);
		keyboardInterface = new KeyboardInterface (playerNumber);
	}

	public GamepadInterface getGamepadInterface() {
		return gamepadInterface;
	}

	public float getMovementHorizontal() {
		float h = gamepadInterface.getLeftStickAxisX ();

		if (floatEqualsZero (h)) {
			h = keyboardInterface.getMovementHorizontal();
		}

		return h;
	}

	public float getMovementVertical() {
		float v = gamepadInterface.getLeftStickAxisY ();
		
		if (floatEqualsZero (v)) {
			v = keyboardInterface.getMovementVertical();
		}
		
		return v;
	}

	public float getLookHorizontal() {
		float h = gamepadInterface.getRightStickAxisX ();
		
		if (floatEqualsZero (h)) {
			h = keyboardInterface.getLookHorizontal();
		}
		
		return h;
	}

	public float getLookVertical() {
		float v = gamepadInterface.getRightStickAxisY ();
		
		if (floatEqualsZero (v)) {
			v = keyboardInterface.getLookVertical();
		}
		
		return v;
	}

	public bool getFire() {
		return (gamepadInterface.isRightTriggerPressed () || keyboardInterface.getFire ());
	}

	private bool floatEqualsZero(float f) {
		if ((Mathf.Abs (f) - epsilon) < 0.0f) {
			return true;
		} else {
			return false;
		}
	}
}
