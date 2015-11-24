using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Ability : MonoBehaviour {
    //TODO: Clean up variables to only the necessary ones
    protected float cooldown;
    public string abilityName { get; set;} 
    public string description { get; set; }
    public Character abilityOwner { get; set; }
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

    public void Init()
    {
        abilityOwner = gameObject.GetComponent<Character>();
    }

    public abstract void Cast();
    public void CastIfPossible()
    {
        if (abilityOwner.CanSetState(stateChain))
        {
            if (abilityOwner.CanSapEnergy(energyCost))
            {
                abilityOwner.SetState(stateChain); //Since this is within one frame there shouldnt be any race conditions....
            }
        }
    }




}
