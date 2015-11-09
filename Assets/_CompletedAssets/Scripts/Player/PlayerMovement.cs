using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;

namespace CompleteProject
{
    public class PlayerMovement : MonoBehaviour
    {
        public float speed = 6f;            // The speed that the player will move at.
        public float currentSpeed;
        public string horizontalAxis;
        public string verticalAxis;
        public KeyCode turnLeft;
        public KeyCode turnRight;
        public string rotX;
        public string rotY;


        Vector3 movement;                   // The vector to store the direction of the player's movement.
        Animator anim;                      // Reference to the animator component.
        Rigidbody playerRigidbody;          // Reference to the player's rigidbody.


        void Awake ()
        {
            playerRigidbody = GetComponent <Rigidbody> ();
        }


        void FixedUpdate ()
        {

            var turnSpeed = 350;
            //this should probably use some input manager
            float x = Input.GetAxisRaw(rotX);
            float y = Input.GetAxisRaw(rotY);

            Turning(x, y);

            if (Input.GetKey(turnLeft))
                transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime);

            if (Input.GetKey(turnRight))
                transform.Rotate(-Vector3.up * turnSpeed * Time.deltaTime);

            // Store the input axes.
            float h = CrossPlatformInputManager.GetAxisRaw(horizontalAxis);
            float v = CrossPlatformInputManager.GetAxisRaw(verticalAxis);

            // Move the player around the scene.
            Move (h, v);


        }

        void Turning(float x, float y)
        {

            var aimPosition = new Vector2(x, y);


            if(aimPosition.magnitude > 0.2)
            {
                var newRotation = Quaternion.AngleAxis(Mathf.Atan2(y, x) * 180/Mathf.PI + 90, Vector3.up);

                playerRigidbody.MoveRotation(newRotation);
            }
            
        }


        void Move (float h, float v)
        {

            
            // Set the movement vector based on the axis input.
            movement.Set (h, 0f, v);
            
            // Normalise the movement vector and make it proportional to the speed per second.
            movement = movement * speed * Time.deltaTime;
            currentSpeed = movement.magnitude * speed;


            // Move the player to it's current position plus the movement.
            playerRigidbody.MovePosition (transform.position + movement);
        }


    }
}