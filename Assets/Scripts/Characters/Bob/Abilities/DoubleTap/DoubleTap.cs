using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DoubleTap : ProjectileAbility {

    float timer;
    float doubleTapInterval = 0.1f;

    public override StateEffect stateChain { get
        {
            //Always return a new chain in case it was mutated
            var preAttackState = new StateEffect(CharacterState.States.PRE_ATTACK, windup, Cast);
            var attackState = new StateEffect(CharacterState.States.BASIC_ATTACK, doubleTapInterval);
            
            return preAttackState + attackState;
        } }

    // Use this for initialization
    void Awake () {
        cooldown = 0.5f;
        windup = 0.2f;
        globalCooldown = 1f;
        name = "Double Tap";
        description = "Shoots 2 bullets yo";
        //The time before you are allowed to move, in this case after second bullet fires.
        float totalStopTime = windup + doubleTapInterval;

        //This is to avoid having to drag and drop projectile prefab. 
        projectile = (Resources.Load("Characters/Bob/Abilities/DoubleTap/DoubleTapProjectile") as GameObject).GetComponent<Rigidbody>();
        projectileSpeed = 25f;
	}


    public override void Cast()
    {
        //this is probably dumb
        Debug.Log("Shooting double tap");
        StartCoroutine(shoot());
    }

    private IEnumerator shoot()
    {
        spawnProjectile(projectile, projectileSpeed, projectileRange);
        yield return new WaitForSeconds(doubleTapInterval);
        spawnProjectile(projectile, projectileSpeed, projectileRange);
    }


}
