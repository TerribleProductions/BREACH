using UnityEngine;
using System.Collections;
using System;

public class Quickshot : ProjectileAbility {


    public override StateEffect stateChain
    {
        get
        {
            //Always return a new chain in case it was mutated
            var preAttackState = new StateEffect(CharacterState.SPECIAL_ATTACK, windup, null, null, Cast);

            return preAttackState;
        }
    }



    // Use this for initialization
    void Awake () {
        Init();
        windup = 0.2f;
        name = "QuickShot";
        description = "Shoots 1 bullet yo";
        energyCost = 60f;

        projectile = (Resources.Load("Characters/Bob/Abilities/Quickshot/QuickshotProjectile") as GameObject).GetComponent<Rigidbody>();
        projectileSpeed = 150f;
        projectileRange = 0;
    }

    public override void Cast()
    {
        if (abilityOwner.SapEnergy(energyCost))
        {
            spawnProjectile(projectile, projectileSpeed, projectileRange);
        }
        
    }

}
