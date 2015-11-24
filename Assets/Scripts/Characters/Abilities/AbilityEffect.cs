using UnityEngine;
using System.Collections;

public abstract class AbilityEffect : MonoBehaviour{

    public GameObject owner;


    public Character GetHitCharacter(Collider collider)
    {
        var enemy = collider.gameObject;
        if(enemy.layer == 9)
        {
            return null;
        }
        Character enemyChar = null;
        if (enemy != null)
        {
            enemyChar = enemy.GetComponent<Character>();
        }
        Destroy(gameObject);
        return enemyChar;
    }

}
