using UnityEngine;
using System.Collections;
using System;

public class Stun : Buff
{

    public float originalSpeed;
    public float duration
    {
        get; set;
    }

    private StateEffect stunState {
        get
        {
            return new StateEffect(CharacterState.States.INACTIVE, duration);
        }
    }

    public Stun(float duration)
    {
        this.duration = duration;
    }

    public void Apply(Character target)
    {
        //This creates a weird coupling between states and buffs since states remove themselves after their duration, so unapply becomes useless.
        //Could be done by having infinte states and unapllying in unapply. Dont know what is best.
        target.stateManager.SetState(stunState);
    }

    public void Unapply(Character target)
    {
        
    }
}
