using UnityEngine;
using System.Collections;
using System;

public class Slow : Buff {

    public float slowPercent = 0.7f; //So 30% slow
    public override float duration {
        get; set;
    }
    public override bool debuff
    {
        get
        {
            return true;
        }
    }
    public override string buffName { get; set; }
    public override bool stackable{get; set;}

    public Slow(float slowPercent, float duration, bool stackable, string name)
    {
        this.duration = duration;
        this.slowPercent = slowPercent;
        this.stackable = stackable;
        this.buffName = name;
    }

    public override void Apply(Character target)
    {
        target.MultiplyMovespeed(slowPercent);
    }

    public override void Unapply(Character target)
    {
        Debug.Log(target.moveSpeedMultiplier);
        target.MultiplyMovespeed(1 / slowPercent);
    }

}
