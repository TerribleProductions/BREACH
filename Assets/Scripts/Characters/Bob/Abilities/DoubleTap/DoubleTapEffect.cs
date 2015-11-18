using UnityEngine;
using System.Collections;

public class DoubleTapEffect : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void OnCollisionEnter()
    {
        Debug.Log("hit someting!");
        var enemy = GetComponent<Character>();
        if(enemy != null)
        {
            Debug.Log("Hit enemy!");
            enemy.hp = -50;
        }
        Destroy(gameObject);
    }
	
	// Update is called once per frame
	void Update () {

        //Do stuff to player in here, like damage and adding buff to self.

        
	
	}
}
