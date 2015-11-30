using UnityEngine;
using System.Collections;
using System;

public class Cleanse : Ability
{

    public override StateEffect stateChain
    {
		get {
			return new StateEffect (CharacterState.SPECIAL_ATTACK, windup, null, null, Cast);
		}
    }


    public override void Cast()
    {
        if (abilityOwner.SapEnergy(energyCost))
        {
            abilityOwner.ClearAllDebuffs();
        }
        
    }

    void Awake()
    {
        Init();
        energyCost = 50f;
        windup = 0.2f;
    }
}
