using UnityEngine;
using System.Collections;

public class QuickshotEffect : AbilityEffect {

    void OnCollisionEnter(Collision collision)
    {
        var enemyChar = GetHitCharacter(collision.collider);
        if(enemyChar != null)
        {
            enemyChar.DamageCharacter(30f);

        }
        Destroy(gameObject);
    }

}
