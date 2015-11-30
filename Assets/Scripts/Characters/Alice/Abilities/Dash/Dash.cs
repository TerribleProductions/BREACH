using UnityEngine;
using System.Collections;
using System;

public class Dash : MovementAbility {

    public override StateEffect stateChain
    {
        get
        {
            var preState = new StateEffect(CharacterState.PRE_ATTACK, windup, Cast, null, null);
            var castState = new StateEffect(CharacterState.SPECIAL_ATTACK, movementTime, null, MoveStep, PostEffect);

            return preState + castState;
        }
    }

    private float movementTime = 0.200f; // Movement time in seconds

	private Vector3 lastUsePosition;
	private float timeSinceLastUse;
	private TrailRenderer trailRenderer;
	
	private float currentTime;
	private Vector3 direction;
    private Vector3 targetPoint;
    private float range;

	// Use this for initialization
	void Awake () {
        Init();
		energyCost = 50f;
		trailRenderer = abilityOwner.GetComponent<TrailRenderer> ();

        range = 8f;
	}

	void MoveStep (){
        Vector3 moveStep = Vector3.MoveTowards(transform.position, targetPoint, range * movementTime);
        MoveToPoint(abilityOwner, moveStep);
	}

    void PostEffect()
    {
        trailRenderer.enabled = false;
    }

	public override void Cast()
    {
        if (abilityOwner.SapEnergy(energyCost))
        {
			direction = abilityOwner.movementVector.normalized;
            Debug.Log(direction);
            targetPoint = transform.position + direction * range;

			// Enable trails
			trailRenderer.enabled = true;

			if (direction.magnitude < 0.01) {
				direction = abilityOwner.transform.forward;
			}
        }
        
    }

}
