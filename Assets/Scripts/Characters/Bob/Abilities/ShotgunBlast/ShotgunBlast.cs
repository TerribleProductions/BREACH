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
        speed = 30f;
        energyCost = 30f;
        projectileAmount = 4;

        rotations = new Quaternion[projectileAmount];
        //How much the forward vector should be rotated for each shot
        for(int i = 0; i < projectileAmount; i++)
        {
            rotations[i] = Quaternion.Euler(0, i * 40 / projectileAmount, 0);
        }
    }
        
    public override void Cast()
    {
        abilityOwner.AddBuff(new Slow(0.4f, 0.25f, false, "shotgunShootSlow"));
        foreach(var rotation in rotations)
        {
            var p = spawnProjectileAngle(projectile, speed, 0, rotation);
        }
    }

    



}
