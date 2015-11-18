using UnityEngine;
using System.Collections;

public class DoubleTapEffect : MonoBehaviour {

    public GameObject owner { get; set; }
    void OnTriggerEnter(Collider collider)
    {
        
        var enemy = collider.gameObject;
        Debug.Log(enemy.name);
        Debug.Log(owner.name);
        if (enemy != null && !enemy.name.Equals(owner.name) && !enemy.name.Equals("Floor") )
        {
            var enemyChar = enemy.GetComponent<Character>();
            Debug.Log("Hit enemy!");
            //enemyChar.hp -= 50;
            Destroy(gameObject);
        }
        
    }
	
	// Update is called once per frame
	void Update () {

        //Do stuff to player in here, like damage and adding buff to self.

        
	
	}
}
