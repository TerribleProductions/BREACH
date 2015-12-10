using UnityEngine;
using System.Collections;
using System;

public class Charge : MovementAbility {


    public override StateEffect stateChain
    {
        get
        {
            var preState = new StateEffect(CharacterState.SPECIAL_ATTACK, windup, Cast, null, null);
            var castState = new StateEffect(CharacterState.IMMOBILE, duration, MoveStep, null, null);
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
        range = 3f;
        duration = 0.2f;
        windup = 0.3f;
        damage = 40f;
    }

    void PostCast()
    {
        var objectsInRange = Physics.OverlapSphere(transform.position, 2f);
        foreach(var obj in objectsInRange)
        {
            var enemy = obj.GetComponent<Character>();
            if ( enemy != null)
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
        var nextPoint = Vector3.MoveTowards(transform.position, targetPoint, range);
        PostCast();
        MoveToPoint(abilityOwner, nextPoint);
    }
}
