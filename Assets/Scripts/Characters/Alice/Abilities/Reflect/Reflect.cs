using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class Reflect : Ability
{
    public override float energyCost { get {
            return 50f;
                } set { } }

    private bool active = false;
    private float radius = 2f;

    public override StateEffect stateChain
    {
        get
        {
            return new StateEffect(CharacterState.CHANNELING, 1f, Cast, null, TriggerUp);
        }

    }

    public override string abilityName
    {
        get; set;
    }

    public override string description
    {
        get; set;
    }

    public override float windup
    {
        get; set;
    }

    public override void Cast()
    {
        if (abilityOwner.SapEnergy(energyCost))
        {
            active = true;
        }
    }

    public override void TriggerUp()
    {
        active = false;
    }

    void Awake()
    {
        base.Init();
    }

    void FixedUpdate()
    {
        if (active)
        {
            
            var objectsInArea = Physics.OverlapSphere(abilityOwner.transform.position, radius);
            Debug.Log(objectsInArea);
            var projectilesInRadius = objectsInArea.Select(obj =>
            {
                return obj.GetComponent<AbilityEffect>();
            }).Where(af =>
            {
                return af != null && af.owner.GetComponent<Character>().playerNumber != abilityOwner.playerNumber;
            }).Select(af =>
            {
                return af.GetComponent<Rigidbody>();
            });
            foreach (Rigidbody rb in projectilesInRadius)
            {
                Debug.Log("Found projectile: " + rb);
                rb.velocity = new Vector3(-rb.velocity.x, rb.velocity.y, -rb.velocity.z);
                rb.GetComponent<AbilityEffect>().owner = abilityOwner.gameObject;
            }
        }
    }

}
