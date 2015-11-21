using UnityEngine;
using System.Collections;
using System;

public class Slow : Buff {

    public float slowPercent = 0.7f; //So 30% slow
    public float originalSpeed;
    public float duration {
        get; set;
    }
    public bool stackable{get; set;}

    public Slow(float slowPercent, float duration, bool stackable)
    {
        this.duration = duration;
        this.slowPercent = slowPercent;
        this.stackable = stackable;
    }

    public void Apply(Character target)
    {
        originalSpeed = target.moveSpeed;
        target.MultiplyMovespeed(slowPercent);
    }

    public void Unapply(Character target)
    {
        target.MultiplyMovespeed(1 / slowPercent);
    }
}
