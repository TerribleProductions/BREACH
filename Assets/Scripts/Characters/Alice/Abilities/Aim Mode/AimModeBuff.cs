using UnityEngine;
using System.Collections.Generic;
using System;

public class AimModeBuff : Buff
{
    public override string buffName { get; set; }

    public override float duration { get; set; }
    public override bool debuff { get
        {
            return false;
        } }
    public override bool stackable { get; set; }

    private Buff aimModeSlow = new Slow(0.05f, Mathf.Infinity, false, "aimModeSlow");

    public AimModeBuff()
    {
        buffName = "aimModeBuff";
        duration = Mathf.Infinity;
        stackable = false;
    }


    public override void Apply(Character target)
    {
        target.AddBuff(aimModeSlow);
    }

    public override void Unapply(Character target)
    {
        target.RemoveBuff(aimModeSlow);
    }
}
