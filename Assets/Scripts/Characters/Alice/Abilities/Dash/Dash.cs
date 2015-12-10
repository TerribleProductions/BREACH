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

    private float movementTime = 0.400f; // Movement time in seconds

	private TrailRenderer trailRenderer;
	
	private float currentTime;
	private Vector3 direction;
    private Vector3 targetPoint;
    private float range;

	// Use this for initialization
	void Awake () {
        Init();
		energyCost = 66f;
		trailRenderer = abilityOwner.GetComponent<TrailRenderer> ();

        range = 10f;
	}

	void MoveStep (){

		// TODO fix movement time
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
            if (direction.magnitude < 0.01)
            {
                direction = abilityOwner.transform.forward;
            }

            targetPoint = transform.position + direction * range;

			RaycastHit hit;
			
			if (Physics.Raycast(transform.position + Vector3.up,  transform.forward + Vector3.up, out hit, range)) {
				if(hit.distance > 3f) {
					targetPoint = transform.position + transform.forward * hit.distance * 0.5f; 
				} else if(hit.distance <= 3f) {
					targetPoint = transform.position;
				}
			}

			// Enable trails
			trailRenderer.enabled = true;
        }
    }

}
