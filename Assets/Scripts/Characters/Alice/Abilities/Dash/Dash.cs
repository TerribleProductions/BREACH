using UnityEngine;
using System.Collections;
using System;

public class Dash : MovementAbility {


    public override float energyCost { get; set; }
    public override float maxRange
    {
        get
        {
            return 2f;
        }
    }

    public override StateEffect stateChain
    {
        get
        {
            return new StateEffect(CharacterState.SPECIAL_ATTACK, 0.05f, null, null, Cast);
        }

        set
        {
            base.stateChain = value;
        }
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
