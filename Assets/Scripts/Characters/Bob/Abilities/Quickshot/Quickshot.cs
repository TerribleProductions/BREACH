using UnityEngine;
using System.Collections;
using System;

public class Quickshot : ProjectileAbility {

    public override float energyCost { get; set; }

    public override StateEffect stateChain
    {
        get
        {
            //Always return a new chain in case it was mutated
            var preAttackState = new StateEffect(CharacterState.SPECIAL_ATTACK, windup, null, Cast, null);

            return preAttackState;
        }
    }

    // Use this for initialization
    void Start () {
        windup = 0.1f;
        name = "QuickShot";
        description = "Shoots 1 bullet yo";

        projectile = (Resources.Load("Characters/Bob/Abilities/Quickshot/QuickshotProjectile") as GameObject).GetComponent<Rigidbody>();
        projectileSpeed = 150f;
        projectileRange = 0;
    }

    public override void Cast()
    {
        spawnProjectile(projectile, projectileSpeed, projectileRange);
    }

}
