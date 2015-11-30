using UnityEngine;
using System.Collections;
using System;

public abstract class MovementAbility : Ability
{
    public float maxRange;

    public override abstract void Cast();

    public void MoveToPoint(Character character, Vector3 point)
    {
        character.transform.position = point;
    }

}
