using UnityEngine;
using System.Collections;
using System;

public class RapidFireEffect : AbilityEffect
{

    public float damage = 10f;


    //TODO: Add collision code here
    void OnCollisionEnter(Collision collision)
    {
        var collider = collision.collider;
        var enemyChar = GetHitCharacter(collider);
        Destroy(gameObject);
        if(enemyChar != null)
        {
            enemyChar.DamageCharacter(damage);
        }
    }


}

