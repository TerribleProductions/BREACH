using UnityEngine;
using System.Collections;
using System;

public class ShadowRaze : Ability {

    public override StateEffect stateChain
    {
        get
        {
            return new StateEffect(CharacterState.IMMOBILE, Mathf.Infinity, preEffect, null, Cast);
        }
    }


    private bool charging;
    private float explosionDuration;
    private Vector3 distance;
    private Vector3 maxDistance;
    private float area;
    private float speed;
    private GameObject distanceEffect;
    private Light distanceEffectLight;
    private GameObject explosionEffect;
    private float damage;

    public override void Cast()
    {
        foreach(Character enemy in AbilityHelper.objectsInAreaExceptOwner<Character>(transform.position, area, abilityOwner.playerNumber))
        {
            enemy.DamageCharacter(damage);
        }
    }

    public override void TriggerUp()
    {
        charging = false;
        explosionDuration = 0.6f;
        distanceEffectLight.range = area;
        Destroy(distanceEffect, 0.1f);
        abilityOwner.SetState(CharacterState.neutralStateEffect);
    }

    public override void CastIfPossible()
    {
        if (!charging)
        {
            base.CastIfPossible();
        }

    }

    private void preEffect()
    {
        charging = true;
        explosionDuration = 0;
        distance = transform.position+transform.forward;
        var distanceEffectPrefab = (Resources.Load("Characters/Bob/Abilities/ShadowRaze/ShadowRazeDistanceEffect") as GameObject);
        distanceEffect = (GameObject)Instantiate(distanceEffectPrefab, transform.position, transform.rotation);
        distanceEffectLight = distanceEffect.GetComponent<Light>();
        distanceEffectLight.range = 1f;
        distanceEffect.transform.position = distance;
        maxDistance = transform.position + transform.forward * 16f;
    }

    // Use this for initialization
    void Awake () {
        Init();
        area = 2f;
        speed = 18f;
        damage = 40f;
        explosionDuration = 0.6f;
        var distanceEffectPrefab = (Resources.Load("Characters/Bob/Abilities/ShadowRaze/ShadowRazeDistanceEffect") as GameObject);
        distanceEffect = (GameObject)Instantiate(distanceEffectPrefab, transform.position, transform.rotation);
        distanceEffectLight = distanceEffect.GetComponent<Light>();
        distanceEffectLight.range = 0;

        //distanceEffect.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
        if (charging)
        {
            float step = speed * Time.deltaTime;
            distance = Vector3.MoveTowards(distance, maxDistance, step);
            distanceEffect.transform.position = distance;
        } 
        
	}
}
