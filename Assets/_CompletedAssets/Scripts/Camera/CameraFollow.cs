using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;            // The position that that camera will be following.
		public Transform target2;
        public float smoothing = 5f;        // The speed with which the camera will be following.


        Vector3 offset;                     // The initial offset from the target.


        void Start ()
        {
            // Calculate the initial offset.
            offset = transform.position;
        }


        void FixedUpdate ()
        {
			float minCameraDistance = 12f;

			// How far the characters are from each other
			float characterDistance = Vector3.Distance (target.transform.position, target2.transform.position);

			// The middle point of the two characters
			Vector3 characterMidpoint = target.position + ((target2.position - target.position) / 2.0f);

			float cameraDistance = Mathf.Max (minCameraDistance, characterDistance / 2.5f);
			Camera.main.orthographicSize = cameraDistance;

            // Create a postion the camera is aiming for based on the offset from the target.
			Vector3 targetCamPos = characterMidpoint + offset;

            // Smoothly interpolate between the camera's current position and it's target position.
            transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);


        }
    }
}