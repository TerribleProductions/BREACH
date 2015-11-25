using UnityEngine;
using System.Collections;
using System;

public class Cleanse : Ability
{
    public override string abilityName
    {
        get; set;
    }

    public override string description
    {
        get; set;
    }

    public override float energyCost { get; set; }

    public override StateEffect stateChain
    {
        get
        {
            return new StateEffect(CharacterState.SPECIAL_ATTACK, windup, null, null, Cast);
        }
    }

    public override float windup
    {
        get; set;
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
