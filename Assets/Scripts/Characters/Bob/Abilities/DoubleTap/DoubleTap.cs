﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class DoubleTap : ProjectileAbility {

    float timer;
    float doubleTapInterval = 0.1f;
    public override float energyCost { get; set; }

    public override StateEffect stateChain { get
        {
            //Always return a new chain in case it was mutated
            var preAttackState = new StateEffect(CharacterState.PRE_ATTACK, windup);
            var attackState = new StateEffect(CharacterState.BASIC_ATTACK, doubleTapInterval, Cast, null, null);
            
            return preAttackState + attackState;
        } }

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

    // Use this for initialization
    void Awake () {
        cooldown = 0.5f;
        windup = 0.2f;
        energyCost = 40f;
        name = "Double Tap";
        description = "Shoots 2 bullets yo";

        abilityOwner = gameObject.GetComponent<Character>();
        //The time before you are allowed to move, in this case after second bullet fires.
        float totalStopTime = windup + doubleTapInterval;

        //This is to avoid having to drag and drop projectile prefab. 
        projectile = (Resources.Load("Characters/Bob/Abilities/DoubleTap/DoubleTapProjectile") as GameObject).GetComponent<Rigidbody>();
        projectileSpeed = 50f;
	}


    public override void Cast()
    {
        if (abilityOwner.SapEnergy(energyCost))
        {
            StartCoroutine(shoot());
        }
        
    }

    private IEnumerator shoot()
    {
        spawnProjectile(projectile, projectileSpeed, projectileRange);
        yield return new WaitForSeconds(doubleTapInterval);
        spawnProjectile(projectile, projectileSpeed, projectileRange);
    }
}
    