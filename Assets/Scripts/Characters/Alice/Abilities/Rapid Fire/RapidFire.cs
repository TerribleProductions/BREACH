using UnityEngine;
using System.Collections;
using System;

public class RapidFire : ProjectileAbility {


    private float timer;

    public override float energyCost { get; set; }

    private float aimModeDamageMultiplier = 1.5f;
    private float aimModeVelocityModifier = 1.5f;

    public override StateEffect stateChain
    {
        get
        {
            //Always return a new chain in case it was mutated
            var attackState = new StateEffect(CharacterState.CHANNELING, Mathf.Infinity, null, Cast, null);
            return attackState;
        }
    }
    void Awake()
    {
        cooldown = 0.125f;
        timer = cooldown;

        energyCost = 10f;

        abilityOwner = gameObject.GetComponent<Character>();

        projectile = (Resources.Load("Characters/Alice/Abilities/RapidFire/RapidFireProjectile") as GameObject).GetComponent<Rigidbody>();
        projectileSpeed = 30f;
    }

    void FixedUpdate()
    {
        //Handle cooldown
        timer -= Time.deltaTime;
    }


    public override void TriggerUp()
    {
        //This is kinda iffy, should try to avoid this coupling somehow.
        gameObject.GetComponent<Character>().SetState(CharacterState.neutralStateEffect);
    }



    public override void Cast()
    {
        
        if (timer <= 0 && abilityOwner.SapEnergy(energyCost))
        {
            timer = cooldown;

            var p = spawnProjectile(projectile, projectileSpeed, 100f);
            if(abilityOwner.HasBuff(new AimModeBuff()))
            {
                var abilityEffect = p.GetComponent<RapidFireEffect>();
                abilityEffect.damage *= aimModeDamageMultiplier;
                p.velocity *= aimModeVelocityModifier;
            }
            //Slow movespeed to simulate some kind of channeling
            abilityOwner.AddBuff(new Slow(0.4f, cooldown*2, false, "rapidFireSlow"));
        }
        
    }
}
