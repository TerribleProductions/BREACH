using UnityEngine;
using System.Collections;

public class Bob : MonoBehaviour {

    float globalTimer = 0;

    struct charAbilities
    {
        public Ability mainAbility;
        public Ability secondaryAbility;
    }
    
    charAbilities abilities; 

	// Use this for initialization
	void Start () {
        abilities = new charAbilities();
        abilities.mainAbility = gameObject.AddComponent<DoubleTap>();
        abilities.secondaryAbility = gameObject.AddComponent<Quickshot>();
	}
	
	// Update is called once per frame
	void Update () {


       globalTimer += Time.deltaTime;

        if(globalTimer > 0.2f)
        {
            
            if (Input.GetButton("Fire1"))
            {
                abilities.mainAbility.Cast();
            }
            if (Input.GetButton("Fire2"))
            {
                abilities.secondaryAbility.Cast();
            }
            globalTimer = 0f;
        }

        
	
	}
}
