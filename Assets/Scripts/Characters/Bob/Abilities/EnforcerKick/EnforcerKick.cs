using UnityEngine;
using System.Collections;
using System;

public class EnforcerKick : MeleeAbility {

	// Use this for initialization
	void Start () {
        area = 100f;
        range = transform.forward *2;
	}

    public override void Cast()
    {
        var closestUnit = GetClosestUnitInRange(area, range);
        Debug.Log(closestUnit);
    }
}
