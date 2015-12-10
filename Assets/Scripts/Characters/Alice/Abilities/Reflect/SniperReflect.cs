using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

public class SniperReflect : Ability
{

    private bool active = false;
    private GameObject reflector;

    private float radius = 3.5f;
    private float knockbackDamage = 15f;

    public override StateEffect stateChain
    {
        get
        {
            return new StateEffect(CharacterState.CHANNELING_IMMOBILE, windup, Cast, null, PostCast);
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

        var reflectorPrefab = Resources.Load("Characters/Alice/Abilities/Reflect/Reflector");
        reflector = Instantiate(reflectorPrefab, transform.position + Vector3.up, transform.rotation) as GameObject;

        energyCost = 50f;
        windup = 0.6f;
    }

    void FixedUpdate()
    {
        if (active)
        {
            reflector.SetActive(true);
            reflector.transform.position = transform.position;

            foreach (Rigidbody rb in projectilesInArea(transform.position, radius))
            {
                rb.velocity = new Vector3(-rb.velocity.x, rb.velocity.y, -rb.velocity.z) * 1.75f;
                rb.GetComponent<AbilityEffect>().owner = abilityOwner.gameObject;
            }
        }
        else
        {
            reflector.SetActive(false);
        }
    }

    private IEnumerable<Rigidbody> projectilesInArea(Vector3 pos, float radius)
    {
        return from af in AbilityHelper.objectsInArea<AbilityEffect>(pos, radius)
               where af != null && af.owner.GetComponent<Character>().playerNumber != abilityOwner.playerNumber
               select af.GetComponent<Rigidbody>();
    }


    private void knockback()
    {

        foreach (var c in AbilityHelper.objectsInAreaExceptOwner<Character>(abilityOwner.transform.position, radius, abilityOwner.playerNumber))
        {
            Debug.Log(c);
            c.DamageCharacter(knockbackDamage);
            var newPos = transform.position + (c.transform.position - transform.position).normalized * radius * 2;
            c.AddBuff(new Slow(0.6f, 0.3f, false, "reflectKnockbackSlow"));
            c.transform.position = newPos;

        }
    }



}
