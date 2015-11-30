using UnityEngine;
using System.Collections;

using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour
{
	public float speed = 10f;
	
	
	void Update ()
	{
		Vector3 rot = new Vector3 (1,1,0);
		transform.Rotate( rot , 15* speed * Time.deltaTime);

	}
}