using UnityEngine;
using System.Collections;

public abstract class AbilityEffect : MonoBehaviour{

    public GameObject owner;


    public Character GetHitCharacter(Collider collider)
    {
        //TODO: Fix this
        var enemy = collider.gameObject;
        Character enemyChar = null;
        if (enemy != null)
        {
            enemyChar = enemy.GetComponent<Character>();
        }
        Destroy(gameObject);
        return enemyChar;
    }

}
