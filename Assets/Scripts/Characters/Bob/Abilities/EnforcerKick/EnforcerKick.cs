using UnityEngine;
using System.Collections;
using System;

public class EnforcerKick : MeleeAbility {

    public override float energyCost
    {
        get; set;
    }

    public override string abilityName
    {
        get; set;
    }

    public override string description
    {
        get; set;
    }

    public override StateEffect stateChain
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    public override float windup
    {
        get; set;
    }

    // Use this for initialization
    void Start () {
        area = 1f;
        range = transform.forward;
	}

    public override void Cast()
    {
        GameObject closestUnit = GetClosestUnitInRange(area, range);
        Debug.Log(closestUnit);
        if(closestUnit != null)
        {
            closestUnit.GetComponent<Rigidbody>().velocity = transform.forward * 10f;
        }
        
       
    }
}
