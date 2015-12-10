using UnityEngine;
using System.Collections;

//This structure becomes a little obtuse
public abstract class ProjectileAbility : Ability {

    public Rigidbody projectile;
    public float projectileSpeed;
    public float projectileRange;

    public Rigidbody spawnProjectile(Rigidbody proj, float pSpeed, float pRange)
    {
        var owner = gameObject;
        var startPos = transform.position + transform.forward * 2f;
        startPos.y = 2f;
        Rigidbody p = (Rigidbody)Instantiate(proj, startPos, transform.rotation);
        //Physics.IgnoreCollision(p.GetComponent<Collider>(), owner.GetComponent<Collider>());
        Physics.IgnoreLayerCollision(8, 9);//Ignore floor
		Physics.IgnoreLayerCollision(9, 9);//Ignore bullets
        p.GetComponent<AbilityEffect>().owner = owner;
        p.velocity = transform.forward * pSpeed;

        return p;
    }

    public Rigidbody spawnProjectileAngle(Rigidbody proj, float pSpeed, float pRange, Quaternion dir)
    {
        Rigidbody p = spawnProjectile(proj, pSpeed, pRange);
        p.transform.forward = dir * p.transform.forward;
		p.transform.position += p.transform.forward * 0.1f;
        p.velocity = p.transform.forward * pSpeed;
        return p;
    }
}
