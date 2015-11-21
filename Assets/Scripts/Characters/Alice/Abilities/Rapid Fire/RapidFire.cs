using UnityEngine;
using System.Collections;
using System;

public class RapidFire : ProjectileAbility {


    private float timer;
    public override StateEffect stateChain
    {
        get
        {
            //Always return a new chain in case it was mutated
            var attackState = new StateEffect(CharacterState.States.CHANNELING, Cast);
            return attackState;
        }
    }
    void Awake()
    {
        cooldown = 0.1f;
        timer = cooldown;

        projectile = (Resources.Load("Characters/Alice/Abilities/RapidFire/RapidFireProjectile") as GameObject).GetComponent<Rigidbody>();
        projectileSpeed = 40f;
    }

    void FixedUpdate()
    {
        //Handle cooldown
        if(timer <= 0)
        {
            timer = cooldown;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    public override void Cast()
    {
        
        if (timer <= 0)
        {
            spawnProjectile(projectile, projectileSpeed, 100f);
            gameObject.GetComponent<Character>().buffManager.AddBuff(new Slow(0.4f, 0.3f, false));
        }
        
    }

}
