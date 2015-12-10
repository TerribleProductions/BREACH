using UnityEngine;
using System.Collections;

public class BigShotEffect : AbilityEffect {

    private float damage = 25f;


    void OnCollisionEnter(Collision collision)
    {
        var enemy = GetHitCharacter(collision.collider);
        if (enemy != null)
        {
            enemy.DamageCharacter(damage);
            enemy.AddBuff(new Stun(0.75f, true, "bigShotStun"));
            Destroy(gameObject);
        }
    }

}
