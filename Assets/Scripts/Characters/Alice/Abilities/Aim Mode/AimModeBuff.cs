using UnityEngine;
using System.Collections.Generic;
using System;

public class AimModeBuff : Buff
{
    public override string buffName { get; set; }

    public override float duration { get; set; }

    public override bool stackable { get; set; }

    private Buff aimModeSlow = new Slow(0.4f, Mathf.Infinity, false, "aimModeSlow");

    public AimModeBuff()
    {
        buffName = "aimModeBuff";
        duration = Mathf.Infinity;
        stackable = false;
    }


    public override void Apply(Character target)
    {
        target.GetComponent<AimMode>().aimLine.enabled = true;
        target.AddBuff(aimModeSlow);
    }

    public override void Unapply(Character target)
    {
        target.GetComponent<AimMode>().aimLine.enabled = false;
        target.RemoveBuff(aimModeSlow);
    }
}
