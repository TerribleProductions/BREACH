using UnityEngine;
using System.Collections;
using System;

public class Dash : MovementAbility {


    public override float energyCost
    {
        get; set;
    }
    public override float maxRange
    {
        get
        {
            return 8f;
        }
    }

    public override StateEffect stateChain
    {
        get
        {
            return new StateEffect(CharacterState.SPECIAL_ATTACK, 0.05f, null, null, Cast);
        }
    }

    public override string abilityName
    {
        get; set;
    }

    public override string description
    {
        get; set;
    }

    public override float windup
    {
        get; set;
    }

    

    // Use this for initialization
    void Awake () {
        energyCost = 50f;
        abilityOwner = gameObject.GetComponent<Character>();
        
	}
	

    public override void Cast()
    {
        if (abilityOwner.SapEnergy(energyCost))
        {
            MoveDirectionDistance(abilityOwner, maxRange);
        }
        
    }

}
