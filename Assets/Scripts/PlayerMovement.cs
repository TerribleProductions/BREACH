using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float movementSpeed = 10f;


    Vector3 movement;                   // The vector to store the direction of the player's movement.
    Rigidbody playerRigidbody;          

    // Use this for initialization
    void Start () {
        playerRigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        Move(x, y);
	
	}

    void Move(float x, float y)
    {
        // Set the movement vector based on the axis input.
        movement.Set(x, 0f, y);

        // Normalise the movement vector and make it proportional to the speed per second.
        movement = movement * movementSpeed * Time.deltaTime;


        // Move the player to it's current position plus the movement.
        playerRigidbody.MovePosition(transform.position + movement);
    }
}
