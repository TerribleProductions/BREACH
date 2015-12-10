using UnityEngine;
using System.Collections;
using System;

public class RapidFire : ProjectileAbility {


    private float timer;

    private Rigidbody quickShotProjectile;
    private float quickShotProjectileSpeed;
    private float quickShotCooldown;
    private float quickShotEnergyCost;

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
        Init();
        cooldown = 0.125f;
        quickShotCooldown = 0.5f;
        timer = 0;

        energyCost = 10f;

        abilityOwner = gameObject.GetComponent<Character>();

        projectile = (Resources.Load("Characters/Alice/Abilities/RapidFire/RapidFireProjectile") as GameObject).GetComponent<Rigidbody>();
        quickShotProjectile = (Resources.Load("Characters/Bob/Abilities/Quickshot/QuickshotProjectile") as GameObject).GetComponent<Rigidbody>();
        projectileSpeed = 25f;
        quickShotProjectileSpeed = 85f;
        quickShotEnergyCost = 75f;
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
        if(timer <= 0)
        {
            if (abilityOwner.HasBuff(new AimModeBuff()))
            {
                if (abilityOwner.SapEnergy(quickShotEnergyCost))
                {
                    spawnProjectile(quickShotProjectile, quickShotProjectileSpeed, 100f);
                    timer = quickShotCooldown;
                }
            }
            else
            {
                if (abilityOwner.SapEnergy(energyCost))
                {
                    spawnProjectile(projectile, projectileSpeed, 100f);
                    timer = cooldown;
                }
            }

            abilityOwner.AddBuff(new Slow(0.4f, cooldown * 2, false, "rapidFireSlow"));
        }

    }
}
