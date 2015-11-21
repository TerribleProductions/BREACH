using UnityEngine;
using System.Collections;
using System;

public class DoubleTapSlow : Buff {

    public float slowPercent = 0.7f; //So 30% slow
    public float originalSpeed;
    public float duration {
        get; set;
    }

    public DoubleTapSlow()
    {
        duration = 3f;
    }

    public void Apply(Character target)
    {
        originalSpeed = target.moveSpeed;
        target.moveSpeed *= slowPercent;
    }

    public void Unapply(Character target)
    {
        target.moveSpeed *= 1 / slowPercent;
    }
}
