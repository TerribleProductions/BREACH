using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Ability : MonoBehaviour {
    //TODO: Clean up variables to only the necessary ones
    public float cooldown { get; set; }
    public string abilityName { get; set;} 
    public string description { get; set; }
    public float castTime { get; set; }
    public virtual StateEffect stateChain { get; set; }
    public float windup { get; set; }

    public abstract float energyCost { get; set; }

    public virtual void TriggerUp()
    {
        return;
    }

    public void TriggerDown()
    {
        Cast();
    }

    public abstract void Cast();

    

	
	
}
