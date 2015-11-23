using UnityEngine;
using System.Collections;
using System;

public class AimMode : Ability
{
    public override float energyCost { get; set; }
    private LineRenderer aimLine;
    Character self;

    public override StateEffect stateChain
    {
        get
        {
            return new StateEffect(CharacterState.States.CHANNELING, Mathf.Infinity, null, Cast, null);
        }
    }

    public void Awake()
    {
        self = gameObject.GetComponent<Character>();
        aimLine = self.gameObject.AddComponent<LineRenderer>();
        aimLine.enabled = false;
    }

    public override void TriggerUp()
    {
        aimLine.enabled = false;
        self.stateManager.SetNeutralState();
    }

    public override void Cast()
    {
        aimLine.enabled = true;
        self.AddBuff(new Slow(0.5f, 0.5f, false, "aimModeSlow"));
    }

    public void Update()
    {
        if (aimLine.enabled)
        {
            var startPos = self.transform.position;
            var endPos = self.transform.forward * 40;
            aimLine.SetPosition(0, startPos);
            aimLine.SetPosition(1, endPos);
        }
        
    }
}
