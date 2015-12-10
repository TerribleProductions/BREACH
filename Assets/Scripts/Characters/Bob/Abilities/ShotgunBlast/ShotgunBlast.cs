using UnityEngine;
using System.Collections;
using System;
using System.Linq;

public class ShotgunBlast : ProjectileAbility {

    public override StateEffect stateChain
    {
        get
        {
            return new StateEffect(CharacterState.BASIC_ATTACK, 0.15f, Cast, null, PostCast);
        }
    }


    private int projectileAmount;
    private float speed;
    private Quaternion[] rotations;
    
    void Awake()
    {
        Init();
        projectile = (Resources.Load("Characters/Bob/Abilities/ShotgunBlast/ShotgunBlastProjectile") as GameObject).GetComponent<Rigidbody>();

        speed = 40f;
        energyCost = 50f;
        projectileAmount = 8;
		int spread = 40;

        rotations = new Quaternion[projectileAmount];
        //How much the forward vector should be rotated for each shot
        for(int i = 0; i < projectileAmount; i++)
        {
            rotations[i] = Quaternion.Euler(0, -(spread / 2.0f) + (spread / projectileAmount) * i, 0);
        }
    }

    public override void Cast()
    {
        if (abilityOwner.CanSapEnergy(energyCost))
        {
            abilityOwner.AddBuff(new Slow(0.2f, 0.25f, false, "shotgunShootSlow"));
        }
        

    }

    public void PostCast()
    {
        if (abilityOwner.SapEnergy(energyCost))
        {
            transform.position = transform.position - transform.forward/3;
			foreach(var rotation in rotations)
            {
                spawnProjectileAngle(projectile, speed, 0, rotation);
            }
        }
        
    }

    



}
