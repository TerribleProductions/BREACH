using UnityEngine;
using System.Collections;

public class GamepadInterface : MonoBehaviour {
	
	private string currentButton;
	private string currentAxis;
	private float axisInput;
	
	private float axisDeadzone = 0.3f;
	private float triggerHardPressTreshhold = 0.9;
	
	public int playerNumber = 1;
	private string playerId;
	
	// Use this for initialization
	void Start () {
		
		// TODO use later when scene has been fixed for multiple controller support
		//playerId = "player " + playerNumber;
		
		playerId = "joystick";
	}
	
	
	/* LEFT STICK */
	
	// Gets the value of the X axis of the left stick. -1 is left, 1 is right
	float getLeftStickAxisX() {
		return Input.GetAxisRaw(playerId + " X axis");
	}
	
	// Returns whether the left stick is tilted left
	bool isLeftStickLeft() {
		return (Input.GetAxisRaw(playerId + " X axis") > axisDeadzone);
	}
	
	// Returns whether the left stick is tilted right
	bool isLeftStickRight() {
		return (Input.GetAxisRaw(playerId + " X axis") < -axisDeadzone);
	}
	
	// Gets the value of the Y axis of the left stick, 1 is up and -1 is right
	float getLeftStickAxisY() {
		return Input.GetAxisRaw(playerId + " Y axis");
	}
	
	// Returns whether the left stick is tilted up
	bool isLeftStickUp() {
		return (Input.GetAxisRaw(playerId + " Y axis") > axisDeadzone);
	}
	
	// Returns whether the left stick is tilted down
	bool isLeftStickDown() {
		return (Input.GetAxisRaw(playerId + " Y axis") < -axisDeadzone);
	}
	
	// Returns whether the left stick has been pressed so it clicks
	bool isLeftStickClicked() {
		return (Input.GetButton(playerId + " button 8"));
	}
	
	
	/* RIGHT STICK */
	
	// Gets the value of the X axis of the right stick. -1 is left, 1 is right
	float getRightStickAxisX() {
		return Input.GetAxisRaw(playerId + " 4th axis");
	}
	
	// Returns whether the right stick is tilted left
	bool isRightStickLeft() {
		return (Input.GetAxisRaw(playerId + " 4th axis") > axisDeadzone);
	}
	
	// Returns whether the right stick is tilted right
	bool isRightStickRight() {
		return (Input.GetAxisRaw(playerId + " 4th axis") < -axisDeadzone);
	}
	
	// Gets the value of the Y axis of the right stick, 1 is up and -1 is right
	float getRightStickAxisY() {
		return Input.GetAxisRaw(playerId + " 5th axis");
	}
	
	// Returns whether the right stick is tilted up
	bool isRightStickUp() {
		return (Input.GetAxisRaw(playerId + " 5th axis") > axisDeadzone);
	}
	
	// Returns whether the right stick is tilted down
	bool isRightStickDown() {
		return (Input.GetAxisRaw(playerId + " 5th axis") < -axisDeadzone);
	}
	
	// Returns the value of the right trigger axis
	float getRightTrigger() {
		return Input.GetAxisRaw(playerId + " 5th axis");
	}
	
	// Returns whether the right stick has been pressed so it clicks
	bool isRightStickClicked() {
		return (Input.GetButton(playerId + " button 9"));
	}
	
	
	/* TRIGGERS */
	
	// Returns the value of the left trigger axis
	float getLeftTrigger() {
		return Input.GetAxisRaw(playerId + " 3rd axis");
	}
	
	// Returns whether the left trigger is pressed
	bool isLeftTriggerPressed() {
		return (Input.GetAxisRaw(playerId + " 3rd axis") > axisDeadzone);
	}
	
	// Returns whether the left trigger is only soft pressed
	bool isLeftTriggerSoftPressed() {
		return (Input.GetAxisRaw(playerId + " 3rd axis") > axisDeadzone && Input.GetAxisRaw(playerId + " 3rd axis") < triggerHardPressTreshhold);
	}
	
	// Returns whether the left trigger is only hard pressed
	bool isLeftTriggerHardPressed() {
		return (Input.GetAxisRaw(playerId + " 3rd axis") > triggerHardPressTreshhold);
	}
	
	// Returns the value of the right trigger axis
	float getRightTrigger() {
		return -Input.GetAxisRaw(playerId + " 3rd axis");
	}
	
	// Returns whether the right trigger is pressed
	bool isRightTriggerPressed() {
		return (Input.GetAxisRaw(playerId + " 3rd axis") < -axisDeadzone);
	}
	
	// Returns whether the right trigger is only soft pressed
	bool isRightTriggerSoftPressed() {
		return (Input.GetAxisRaw(playerId + " 3rd axis") < -axisDeadzone && Input.GetAxisRaw(playerId + " 3rd axis") > -triggerHardPressTreshhold);
	}
	
	// Returns whether the right trigger is only hard pressed
	bool isRightTriggerHardPressed() {
		return (Input.GetAxisRaw(playerId + " 3rd axis") < -triggerHardPressTreshhold);
	}
	
	
	/* D-pad */
	
	// Returns whether D-pad is pressed left
	bool isDpadLeft() {
		return (Input.GetAxisRaw(playerId + " 6th axis") > axisDeadzone);
	}
	
	// Returns whether D-pad is pressed right
	bool isDpadRight() {
		return (Input.GetAxisRaw(playerId + " 6th axis") < -axisDeadzone);
	}
	
	// Returns whether D-pad is pressed up
	bool isDpadUp() {
		return (Input.GetAxisRaw(playerId + " 7th axis") > axisDeadzone);
	}
	
	// Returns whether D-pad is pressed down
	bool isDpadDown() {
		return (Input.GetAxisRaw(playerId + " 7th axis") > axisDeadzone);
	}
	
	
	/* Buttons */
	
	// Returns whether the A button is pressed
	bool isAPressed() {
		return Input.GetButton(playerId + " button 0");
	}
	
	// Returns whether the B button is pressed
	bool isBPressed() {
		return Input.GetButton(playerId + " button 1");
	}
	
	// Returns whether the X button is pressed
	bool isXPressed() {
		return Input.GetButton(playerId + " button 2");
	}
	
	// Returns whether the Y button is pressed
	bool isYPressed() {
		return Input.GetButton(playerId + " button 3");
	}
	
	// Returns whether the left bumper is pressed
	bool isLeftBumperPressed() {
		return Input.GetButton(playerId + " button 4");
	}
	
	// Returns whether the left bumper is pressed
	bool isLeftBumperPressed() {
		return Input.GetButton(playerId + " button 4");
	}
	
	// Returns whether the right bumper is pressed
	bool isLeftRightPressed() {
		return Input.GetButton(playerId + " button 5");
	}
	
	// Returns whether the back button is pressed
	bool isBackPressed() {
		return Input.GetButton(playerId + " button 6");
	}
	
	// Returns whether the start button is pressed
	bool isStartPressed() {
		return Input.GetButton(playerId + " button 7");
	}
}
