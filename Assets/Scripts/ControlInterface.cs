using UnityEngine;
using System.Collections;

public class ControlInterface {
	
	private GamepadInterface gamepadInterface;
	private KeyboardInterface keyboardInterface;

	private float epsilon = 0.001f;

	public ControlInterface(int playerNumber){
		gamepadInterface = new GamepadInterface (playerNumber);
		keyboardInterface = new KeyboardInterface (playerNumber);
	}

	public GamepadInterface getGamepadInterface() {
		return gamepadInterface;
	}

	public float getMovementHorizontal() {
		float h = gamepadInterface.getLeftStickAxisX ();

		if (equalsZero (h)) {
			h = keyboardInterface.getMovementHorizontal();
		}

		return h;
	}

	public float getMovementVertical() {
		float v = gamepadInterface.getLeftStickAxisY ();
		
		if (equalsZero (v)) {
			v = keyboardInterface.getMovementVertical();
		}
		
		return v;
	}

	public float getLookHorizontal() {
		float h = gamepadInterface.getRightStickAxisX ();
		
		if (equalsZero (h)) {
			h = keyboardInterface.getLookHorizontal();
		}
		
		return h;
	}

	public float getLookVertical() {
		float v = gamepadInterface.getRightStickAxisY ();
		
		if (equalsZero (v)) {
			v = keyboardInterface.getLookVertical();
		}
		
		return v;
	}

	public bool getFire() {
		return (gamepadInterface.isRightTriggerPressed () || keyboardInterface.getFire ());
	}

    public bool getFireSecondary()
    {
        return (gamepadInterface.isLeftTriggerPressed() || keyboardInterface.getFireSecondary());
    }

    public bool getFireUp()
    {
		return (keyboardInterface.getFireUp() || (!gamepadInterface.isRightTriggerPressed () && !keyboardInterface.getFire ()));
    }

    public bool getFireSecondaryUp()
    {
        return (keyboardInterface.getFireUp2() || (!gamepadInterface.isLeftTriggerPressed() && !keyboardInterface.getFireSecondary()));
    }

    public bool getAbility() {
		return (gamepadInterface.isLeftBumperPressed () || keyboardInterface.getAbility ());
	}

	public bool getAbilitySecondary() {
		return (gamepadInterface.isRightBumperPressed () || keyboardInterface.getAbilitySecondary ());
	}

	public bool equalsZero(float f) {
		if ((Mathf.Abs (f) - epsilon) < 0.0f) {
			return true;
		} else {
			return false;
		}
	}

	public bool equalsZero(Vector3 v) {
		Vector3 zero = new Vector3 (0f, 0f, 0f);
		float distance = Vector3.Distance (v, zero);

		return equalsZero (distance);
	}

}
