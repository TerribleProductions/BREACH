using UnityEngine;
using System.Collections;
using System;

public class Stun : Buff
{

    public float originalSpeed;
    public override float duration
    {
        get; set;
    }
    public override bool stackable { get; set; }
    public override string buffName { get; set; }

    private StateEffect stunState {
        get
        {
            return new StateEffect(CharacterState.States.INACTIVE, duration);
        }
    }

    public Stun(float duration, bool stackable, string name)
    {
        this.duration = duration;
        this.stackable = stackable;
        this.buffName = name;
    }

    public override void Apply(Character target)
    {
        //This creates a weird coupling between states and buffs since states remove themselves after their duration, so unapply becomes useless.
        //Could be done by having infinte states and unapllying in unapply. Dont know what is best.
        target.SetState(stunState);
    }

    public override void Unapply(Character target)
    {
        
    }
}
