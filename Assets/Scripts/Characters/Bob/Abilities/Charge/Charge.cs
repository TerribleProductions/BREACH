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
    
    void Awake()
    {
        Init();
        range = 10f;
        duration = 0.4f;
        windup = 0.01f;
        damage = 25f;
    }

    void PostCast()
    {
        var objectsInRange = Physics.OverlapSphere(transform.position, 2f);
        foreach(var obj in objectsInRange)
        {
            var enemy = obj.GetComponent<Character>();
            if ( enemy != null && enemy.playerNumber != abilityOwner.playerNumber)
            {
                enemy.DamageCharacter(damage);
            }
        }
    }

    public override void Cast()
    {
        targetPoint = transform.position + transform.forward * range;
        Debug.Log(targetPoint);
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
