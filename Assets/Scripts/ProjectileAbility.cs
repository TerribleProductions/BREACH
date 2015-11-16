using UnityEngine;
using System.Collections;

//This structure becomes a little obtuse
public abstract class ProjectileAbility : Ability {

    public Rigidbody projectile;
    public float projectileSpeed;
    public float projectileRange;

    public void spawnProjectile(Rigidbody proj, float pSpeed, float pRange)
    {
        var p = (Rigidbody)Instantiate(proj, transform.position, transform.rotation);
        p.velocity = transform.forward * pSpeed;
    }
}
