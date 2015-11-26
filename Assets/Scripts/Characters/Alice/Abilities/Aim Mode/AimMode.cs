using UnityEngine;
using System.Collections;
using System;

public class AimMode : Ability
{
    public override float energyCost { get; set; }
    public LineRenderer aimLine;
    Character self;
    Buff buff;

    public override StateEffect stateChain
    {
        get
        {
            return new StateEffect(CharacterState.NEUTRAL, Mathf.Infinity, Cast, null, null);
        }
    }

    public override string abilityName
    {
        get; set;
    }
    public override string description
    {
        get; set;
    }

    public override float windup
    {
        get; set;
    }

    void Awake()
    {
        base.Init();
        buff = new Slow(0.4f, Mathf.Infinity, false, "aimModeSlow");
        self = gameObject.GetComponent<Character>();
        aimLine = self.gameObject.AddComponent<LineRenderer>();
        aimLine.enabled = false;
        aimLine.SetWidth(0.1f, 0.1f);
    }

    public override void TriggerUp()
    {
        self.RemoveBuff(buff);
        aimLine.enabled = false;
    }

    public override void Cast()
    {
        self.AddBuff(buff);
        aimLine.enabled = true;
    }

    void Update()
    {
        if (aimLine.enabled)
        {
            var startPos = self.transform.position;
            startPos.y = 1.1f; //Otherwise ray is rendered beneath the floor sometimes
            var endPos = startPos + self.transform.forward * 20;
            endPos.y = 1.1f;
            aimLine.SetPosition(0, startPos);
            aimLine.SetPosition(1, endPos);
        }
        
    }

}
