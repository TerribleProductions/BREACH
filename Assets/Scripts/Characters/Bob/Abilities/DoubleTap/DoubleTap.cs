using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DoubleTap : ProjectileAbility {

    float timer;
    float doubleTapInterval = 0.1f;

    // Use this for initialization
    void Start () {
        cooldown = 0.5f;
        windup = 0.2f;
        globalCooldown = 1f;
        name = "Double Tap";
        description = "Shoots 2 bullets yo";
        //The time before you are allowed to move, in this case after second bullet fires.
        float totalStopTime = windup + doubleTapInterval;

        preAttackState = new StateEffect(CharacterState.States.PRE_ATTACK, windup, Cast);
        attackState = new StateEffect(CharacterState.States.BASIC_ATTACK, doubleTapInterval, null);
        

        projectile = (Resources.Load("Characters/Bob/Abilities/DoubleTap/DoubleTapProjectile") as GameObject).GetComponent<Rigidbody>();
        projectileSpeed = 25f;
	}


    public override void Cast()
    {
        //this is probably dumb
        
        StartCoroutine(shoot());
    }

    private IEnumerator shoot()
    {
        yield return new WaitForSeconds(windup);
        spawnProjectile(projectile, projectileSpeed, projectileRange);
        yield return new WaitForSeconds(doubleTapInterval);
        spawnProjectile(projectile, projectileSpeed, projectileRange);
    }


}
