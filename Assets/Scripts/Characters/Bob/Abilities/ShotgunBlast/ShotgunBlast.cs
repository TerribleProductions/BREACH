using UnityEngine;
using System.Collections;
using System;
using System.Linq;

public class ShotgunBlast : ProjectileAbility {

    public override StateEffect stateChain
    {
        get
        {
            return new StateEffect(CharacterState.BASIC_ATTACK, 0.3f, Cast, null, null);
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
        energyCost = 40f;
        projectileAmount = 6;
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
        if (abilityOwner.SapEnergy(energyCost))
        {
            abilityOwner.AddBuff(new Slow(0.4f, 0.25f, false, "shotgunShootSlow"));
			foreach(var rotation in rotations)
            {
                spawnProjectileAngle(projectile, speed, 0, rotation);
            }
        }
        
    }

    



}
