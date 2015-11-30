using UnityEngine;
using System.Collections;

using UnityEngine;
using System.Collections;

public class SpinFirstAid : MonoBehaviour
{
	public float speed = 10f;
	
	
	void Update ()
	{
		Vector3 rot = new Vector3 (0,0,1);
		transform.Rotate( rot , 20* speed * Time.deltaTime);
		
	}
}