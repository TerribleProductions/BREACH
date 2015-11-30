using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Ability : MonoBehaviour {
    //TODO: Clean up variables to only the necessary ones
    
    public abstract StateEffect stateChain { get; }

    protected float cooldown;
    protected Character abilityOwner;
    protected float windup;

    public string abilityName;
    public string description;
    public float energyCost;

    public virtual void TriggerUp()
    {
        return;
    }

    public void Init()
    {
        abilityOwner = gameObject.GetComponent<Character>();
    }

    public abstract void Cast();
    public virtual void CastIfPossible()
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
