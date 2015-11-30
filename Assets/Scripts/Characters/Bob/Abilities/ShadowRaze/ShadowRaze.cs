﻿using UnityEngine;
using System.Collections;
using System;

public class ShadowRaze : Ability {
    public override string abilityName { get; set; }

    public override string description { get; set; }

    public override float energyCost { get; set; }

    public override StateEffect stateChain
    {
        get
        {
            return new StateEffect(CharacterState.IMMOBILE, Mathf.Infinity, preEffect, null, Cast);
        }
    }

    public override float windup { get; set; }

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
        var objectsInExplosion = Physics.OverlapSphere(distance, area);
        Debug.Log(objectsInExplosion);
        foreach(Collider obj in objectsInExplosion)
        {
            var enemy = obj.gameObject.GetComponent<Character>();
            if(enemy != null)
            {
                enemy.DamageCharacter(damage);
            }
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
        maxDistance = transform.position + transform.forward * 8f;
    }

    // Use this for initialization
    void Awake () {
        Init();
        area = 2f;
        speed = 8f;
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
