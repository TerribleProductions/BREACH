using UnityEngine;
using System.Collections;

public class DoubleTapEffect : AbilityEffect {

    public override Buff buff
    {
        get
        {
            return new Slow(0.7f, 2, true);
        }
    }


    void OnTriggerEnter(Collider collider)
    {
        //TODO: Fix this
        var enemy = collider.gameObject;
        if (enemy != null) { 
            var enemyChar = enemy.GetComponent<Character>();
            
            Debug.Log(enemyChar);
            if (enemyChar != null)
            {
                Debug.Log(enemyChar);
                enemyChar.buffManager.AddBuff(buff);
                enemyChar.hp -= 50;
               
            }
            Destroy(gameObject);
        }

    }
}
