using UnityEngine;
using System.Collections;

//This structure becomes a little obtuse
public abstract class ProjectileAbility : Ability {

    public Rigidbody projectile;
    public float projectileSpeed;
    public float projectileRange;

    public void spawnProjectile(Rigidbody proj, float pSpeed, float pRange)
    {
        var owner = gameObject;
        var startPos = transform.position;
        startPos.y = 2f;
        Rigidbody p = (Rigidbody)Instantiate(proj, startPos, transform.rotation);
        Physics.IgnoreCollision(p.GetComponent<Collider>(), owner.GetComponent<Collider>());
        Physics.IgnoreLayerCollision(8, 9);//Ignore floor
        p.GetComponent<AbilityEffect>().owner = owner;
        p.velocity = transform.forward * pSpeed;
    }
}
