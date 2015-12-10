using UnityEngine;
using System.Collections;

public class QuickshotEffect : AbilityEffect {

    void OnCollisionEnter(Collision collision)
    {
        var enemyChar = GetHitCharacter(collision.collider);
        if(enemyChar != null)
        {
            enemyChar.DamageCharacter(40f);
            enemyChar.AddBuff(new Stun(0.5f, false, "quickshotStun"));
        }
        Destroy(gameObject);
    }

}
