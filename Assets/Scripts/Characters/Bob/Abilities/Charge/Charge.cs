using UnityEngine;
using System.Collections;
using System;

public class Charge : MovementAbility {


    public override StateEffect stateChain
    {
        get
        {
            var preState = new StateEffect(CharacterState.SPECIAL_ATTACK, windup, Cast, null, null);
            var castState = new StateEffect(CharacterState.IMMOBILE, duration, null, MoveStep, PostCast);
            //var postState = new StateEffect(CharacterState.IMMOBILE, 0.1f, null, null, null);
            return preState + castState;
        }
    }


    private float range;
    private float duration;
    private Vector3 targetPoint;
    private float damage;
    private float radius;

	private TrailRenderer trailRenderer;

    void Awake()
    {
        Init();
        range = 10f;
        duration = 0.4f;
        windup = 0.01f;
        damage = 25f;
        radius = 3f;

		trailRenderer = abilityOwner.GetComponent<TrailRenderer> ();
    }

    void PostCast()
    {
        foreach(var enemy in AbilityHelper.objectsInAreaExceptOwner<Character>(transform.position, radius, abilityOwner.playerNumber))
        {
            enemy.DamageCharacter(damage);
        }

		trailRenderer.enabled = false;

		var chargeImpactPrefab = (Resources.Load("Characters/Bob/Abilities/Charge/Charge") as GameObject);
		GameObject chargeImpact = (GameObject)Instantiate(chargeImpactPrefab, transform.position, transform.rotation);
		Destroy(chargeImpact, 0.5f); 
    }

    public override void Cast()
    {
        if (abilityOwner.SapEnergy(energyCost))
        {
            targetPoint = transform.position + transform.forward * range;
            trailRenderer.enabled = true;
        }
        
    }

    void MoveStep()
    {
        var distanceTraveled = range - (targetPoint - transform.position).magnitude;
        //exponential easing
        float stepLength = range * 0.15f * Mathf.Pow(2, 10 * (distanceTraveled / range ) - 4);

        var nextPoint = Vector3.MoveTowards(transform.position, targetPoint, stepLength);
        Debug.Log(distanceTraveled);
        
        MoveToPoint(abilityOwner, nextPoint);
    }
}
