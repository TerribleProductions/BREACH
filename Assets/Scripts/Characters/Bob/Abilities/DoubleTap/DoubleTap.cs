using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DoubleTap : ProjectileAbility {

    float timer;
    float doubleTapInterval = 0.1f;

    // Use this for initialization
    void Start () {
        cooldown = 0.5f;
        globalCooldown = 1f;
        name = "Double Tap";
        description = "Shoots 2 bullets yo";

        stateEffect = new StateEffect(CharacterState.States.BASIC_ATTACK, cooldown);

        projectile = (Resources.Load("Characters/Bob/Abilities/DoubleTap/DoubleTapProjectile") as GameObject).GetComponent<Rigidbody>();
        projectileSpeed = 100f;
	}


    public override void Cast()
    {
        //this is probably dumb
        StartCoroutine(shoot());
    }

    private IEnumerator shoot()
    {       
        spawnProjectile(projectile, projectileSpeed, projectileRange);
        yield return new WaitForSeconds(doubleTapInterval);
        spawnProjectile(projectile, projectileSpeed, projectileRange);
    }


}
