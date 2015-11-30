using UnityEngine;
using System.Collections;

public class ShotgunBlastEffect : AbilityEffect {

    private float maxRangeInTime;
    private float timer;
    private float damage = 5f;

    void Awake()
    {
        maxRangeInTime = 1f;
        timer = 0;
    }
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= maxRangeInTime)
        {
                Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        var enemy = GetHitCharacter(collision.collider);
        if(enemy != null)
        {
            enemy.DamageCharacter(damage);
            //enemy.transform.position -= -transform.forward;
            enemy.AddBuff(new Slow(0.75f, 0.3f, true, "shotgunSlow"));
            Destroy(gameObject);
        }
    }

}
