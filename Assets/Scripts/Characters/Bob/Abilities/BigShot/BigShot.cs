using UnityEngine;
using System.Collections;
using System;

public class BigShot : ProjectileAbility
{
    public override StateEffect stateChain
    {
        get
        {
            return new StateEffect(CharacterState.CHANNELING_IMMOBILE, 0.1f, null, null, Cast);
        }
    }

    public override void Cast()
    {

        if (abilityOwner.SapEnergy(energyCost))
        {
            var owner = gameObject;
            var startPos = transform.position + transform.forward * 4f;
            startPos.y = 2f;
            Rigidbody p = (Rigidbody)Instantiate(projectile, startPos, transform.rotation);
            //Physics.IgnoreCollision(p.GetComponent<Collider>(), owner.GetComponent<Collider>());
            Physics.IgnoreLayerCollision(8, 9);//Ignore floor
            Physics.IgnoreLayerCollision(9, 9);//Ignore bullets
            p.GetComponent<AbilityEffect>().owner = owner;
            p.velocity = transform.forward * speed;
            p.GetComponent<AbilityEffect>().owner = abilityOwner.gameObject;

        }

    }


    private float speed;

    void Awake()
    {
        Init();

        projectile = (Resources.Load("Characters/Bob/Abilities/BigShot/BigShotProjectile") as GameObject).GetComponent<Rigidbody>();
        speed = 30f ; ;
        energyCost = 80f;
    }
}
