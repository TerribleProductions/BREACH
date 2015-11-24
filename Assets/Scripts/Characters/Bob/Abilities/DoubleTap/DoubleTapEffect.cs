using UnityEngine;
using System.Collections;

public class DoubleTapEffect : AbilityEffect {

    public Buff buff
    {
        get
        {
            return new Slow(0.7f, 2, true, "doubleTapSlow");
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        var collider = collision.collider;
        var enemyChar = GetHitCharacter(collider);
        if (enemyChar != null)
        {
            enemyChar.AddBuff(buff);
            enemyChar.DamageCharacter(50);
        }
    }

}
