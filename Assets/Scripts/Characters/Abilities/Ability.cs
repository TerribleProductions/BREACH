using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Ability : MonoBehaviour {
    //TODO: Clean up variables to only the necessary ones
    protected float cooldown;
    public abstract string abilityName { get; set; } 
    public abstract  string description { get; set; }
    public Character abilityOwner { get; set; }
    public abstract StateEffect stateChain { get; }
    public abstract float windup { get; set; }

    public abstract float energyCost { get; set; }

    public virtual void TriggerUp()
    {
        return;
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
