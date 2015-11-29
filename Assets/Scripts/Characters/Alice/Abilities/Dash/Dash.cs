using UnityEngine;
using System.Collections;
using System;

public class Dash : MovementAbility {

	private float movementTime = 0.200f; // Movement time in seconds

	private Vector3 lastUsePosition;
	private float timeSinceLastUse;
	TrailRenderer trailRenderer;

	private float currentTime;
	private Vector3 direction;

	// Use this for initialization
	void Awake () {
		energyCost = 50f;
		abilityOwner = gameObject.GetComponent<Character>();
		trailRenderer = abilityOwner.GetComponent<TrailRenderer> ();
	}

	void FixedUpdate (){
		currentTime = Time.timeSinceLevelLoad;

		if ((currentTime - timeSinceLastUse) < movementTime) {
			MoveDirectionDistance (abilityOwner, maxRange);
		} else {
			trailRenderer.enabled = false;
		}
	}

    public override float energyCost
    {
        get; set;
    }
    public override float maxRange
    {
        get
        {
            return 8f;
        }
    }

    public override StateEffect stateChain
    {
        get
        {
            return new StateEffect(CharacterState.SPECIAL_ATTACK, 0.05f, null, null, Cast);
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

	public override void Cast()
    {
        if (abilityOwner.SapEnergy(energyCost))
        {
			lastUsePosition = abilityOwner.transform.position;
			timeSinceLastUse = Time.timeSinceLevelLoad;

			trailRenderer.enabled = true;

			direction = abilityOwner.movementVector;
			
			if (direction.magnitude < 0.01) {
				direction = abilityOwner.transform.forward;
			}

            MoveDirectionDistance(abilityOwner, maxRange);
        }
        
    }

	public override void MoveDirectionDistance(Character character, float distance)
	{
		float movementPercent = (currentTime - timeSinceLastUse) / movementTime;
		character.transform.position = lastUsePosition + direction.normalized * distance * movementPercent;
	}

}
