using UnityEngine;
using System.Collections;

public class Quickshot : ProjectileAbility {

	// Use this for initialization
	void Start () {
        cooldown = 0.5f;
        globalCooldown = 1f;
        name = "QuickShot";
        description = "Shoots 1 bullet yo";

        projectile = (Resources.Load("Characters/Bob/Abilities/Quickshot/QuickshotProjectile") as GameObject).GetComponent<Rigidbody>();
        projectileSpeed = 150f;
        projectileRange = 0;
    }

    public override void Cast()
    {
        spawnProjectile(projectile, projectileSpeed, projectileRange);
    }
	
}
