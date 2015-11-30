using UnityEngine;
using System.Collections;
using System;

public class ShotgunBlast : ProjectileAbility {
    public override string abilityName { get; set; }

    public override string description { get; set; }

    public override float energyCost { get; set; }

    public override StateEffect stateChain
    {
        get
        {
            return new StateEffect(CharacterState.BASIC_ATTACK, 0.3f, Cast, null, null);
        }
    }

    public override float windup { get; set; }

    private int projectileAmount;
    private float speed;

    void Awake()
    {
        Init();
        projectile = (Resources.Load("Characters/Bob/Abilities/ShotgunBlast/ShotgunBlastProjectile") as GameObject).GetComponent<Rigidbody>();
        speed = 30f;
        energyCost = 30f;
        projectileAmount = 4;   
    }

    public override void Cast()
    {

        for(int i = -projectileAmount/2; i < projectileAmount/2; i++){
            Quaternion dir = Quaternion.Euler(0, i * 20 / projectileAmount, 0);
            spawnProjectileAngle(projectile, speed, 0, dir);
        }
    }

    



}
