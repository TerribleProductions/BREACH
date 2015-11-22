using UnityEngine;
using System.Collections;
using System;

public class EnforcerKick : MeleeAbility {

    public override float energyCost
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
