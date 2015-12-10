using UnityEngine;
using System.Collections;
using System;

public class AimMode : Ability
{


    public LineRenderer aimLine;
    Buff buff;

    public override StateEffect stateChain
    {
        get
        {
            return new StateEffect(CharacterState.NEUTRAL, Mathf.Infinity, Cast, null, null);
        }
    }

    void Awake()
    {
        base.Init();
        buff = new AimModeBuff();
        aimLine = abilityOwner.gameObject.AddComponent<LineRenderer>();
		aimLine.material = (Material) Resources.Load ("Characters/Alice/Abilities/AimMode/SniperColorMaterial");
        aimLine.enabled = false;
        aimLine.SetWidth(0.1f, 0.1f);
    }

    public override void TriggerUp()
    {
        abilityOwner.RemoveBuff(buff);
        aimLine.enabled = false;
    }

    public override void Cast()
    {
        abilityOwner.AddBuff(buff);
        aimLine.enabled = true;
    }

    public override void CastIfPossible()
    {
        if (!abilityOwner.HasBuff(buff))
        {
            base.CastIfPossible();
        }
        
    }

    void Update()
    {
        if (aimLine.enabled)
        {
            var startPos = abilityOwner.transform.position;
            startPos.y = 2f; //Otherwise ray is rendered beneath the floor sometimes
            var endPos = startPos + abilityOwner.transform.forward * 20;
            endPos.y = 2f;
            aimLine.SetPosition(0, startPos);
            aimLine.SetPosition(1, endPos);
        }
        
    }

}
