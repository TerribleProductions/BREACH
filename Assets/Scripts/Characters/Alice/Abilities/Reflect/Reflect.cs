using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

public class Reflect : Ability
{

    private bool active = false;
    private float radius = 2f;
    private float knockbackDamage = 15f;

    public override StateEffect stateChain
    {
        get
        {
            return new StateEffect(CharacterState.IMMOBILE, windup, Cast, null, PostCast);
        }

    }


    public override void Cast()
    {
        if (abilityOwner.SapEnergy(energyCost))
        {
            active = true;
            knockback();
        }
    }

    public void PostCast()
    {
        active = false;
    }

    void Awake()
    {
        base.Init();
        energyCost = 50f;
        windup = 0.6f;
    }

    void FixedUpdate()
    {
        if (active)
        {
            foreach (Rigidbody rb in projectilesInArea(transform.position, radius))
            {
                rb.velocity = new Vector3(-rb.velocity.x, rb.velocity.y, -rb.velocity.z);
                rb.GetComponent<AbilityEffect>().owner = abilityOwner.gameObject;
            }
        }
    }

    private IEnumerable<Rigidbody> projectilesInArea(Vector3 pos, float radius)
    {
        return from obj in objectsInArea(pos, radius)
                select obj.GetComponent<AbilityEffect>() into af
                where af != null && af.owner.GetComponent<Character>().playerNumber != abilityOwner.playerNumber
                select af.GetComponent<Rigidbody>();
    }

    private IEnumerable<GameObject> objectsInArea(Vector3 pos, float radius)
    {
        return from collider in Physics.OverlapSphere(pos, radius)
               select collider.gameObject;
    }

    private IEnumerable<Character> charactersInArea(Vector3 pos, float radius)
    {
        return from go in objectsInArea(pos, radius)
               select go.GetComponent<Character>() into c
               where c != null && c.playerNumber != abilityOwner.playerNumber
               select c;
    }

    private void knockback()
    {
        
        foreach(var c in charactersInArea(abilityOwner.transform.position, radius))
        {
            Debug.Log(c);
            c.DamageCharacter(knockbackDamage);
            var newPos = transform.position + (c.transform.position - transform.position).normalized * radius * 2;
            c.AddBuff(new Slow(0.6f, 0.3f, false, "reflectKnockbackSlow"));
            c.transform.position = newPos;

        }
    }



}
