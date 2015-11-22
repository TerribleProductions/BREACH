using UnityEngine;
using System.Collections;
using System;

public class RapidFire : ProjectileAbility {


    private float timer;

    public override float energyCost { get; set; }
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

        energyCost = 10f;

        projectile = (Resources.Load("Characters/Alice/Abilities/RapidFire/RapidFireProjectile") as GameObject).GetComponent<Rigidbody>();
        projectileSpeed = 40f;
    }

    void FixedUpdate()
    {
        //Handle cooldown
        timer -= Time.deltaTime;
    }

    public void TriggerDown()
    {
        Cast();
    }

    public override void TriggerUp()
    {
        Debug.Log("Button released");
        //This is kinda iffy, should try to avoid this coupling somehow.
        gameObject.GetComponent<Character>().stateManager.SetNeutralState();
    }

    public override void Cast()
    {
        
        if (timer <= 0)
        {
            timer = cooldown;

            spawnProjectile(projectile, projectileSpeed, 100f);

            //Slow movespeed to simulate some kind of channeling
            gameObject.GetComponent<Character>().AddBuff(new Slow(0.4f, 0.3f, false));
        }
        
    }

}
