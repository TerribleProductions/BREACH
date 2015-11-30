using UnityEngine;
using System.Collections;
using System;

public abstract class MovementAbility : Ability
{
    public override abstract float energyCost
    {
        get; set;
    }

    public abstract float maxRange
    {
        get;
    }

    public override abstract void Cast();

    public void MoveToPoint(Character character, Vector3 point)
    {
        character.transform.position = point;
    }

	public abstract void MoveDirectionDistance(Character character, float distance);
}
