using UnityEngine;
using System.Collections;

public class Bob : MonoBehaviour {

    struct charAbilities
    {
        public Ability mainAttack;
    }
    
    charAbilities abilities; 

	// Use this for initialization
	void Start () {
        abilities = new charAbilities();
        abilities.mainAttack = GetComponent<DoubleTap>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButton("Fire1"))
        {
            abilities.mainAttack.Cast();
        }
	
	}
}
