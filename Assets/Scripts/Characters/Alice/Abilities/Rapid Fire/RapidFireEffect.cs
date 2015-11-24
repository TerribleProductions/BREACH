using UnityEngine;
using System.Collections;
using System;

public class RapidFireEffect : AbilityEffect
{

    public float damage = 10f;


    //TODO: Add collision code here
    void OnTriggerEnter(Collider collider)
    {
        var enemyChar = GetHitCharacter(collider);
        if(enemyChar != null)
        {
            enemyChar.DamageCharacter(damage);
        }
    }


}

