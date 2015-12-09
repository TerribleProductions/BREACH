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
    private float damage;

	private Vector3 aboveGround = new Vector3(0f, 1f, 0f);

    public override void Cast()
    {
        var objectsInExplosion = Physics.OverlapSphere(distance, area);
        //zDebug.Log(objectsInExplosion);
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

		var explosionPrefab = (Resources.Load("Characters/Bob/Abilities/ShadowRaze/Raze") as GameObject);
		GameObject explosionEffect = (GameObject)Instantiate(explosionPrefab, distanceEffect.transform.position, distanceEffect.transform.rotation);
		Destroy(explosionEffect, explosionEffect.GetComponent<ParticleSystem>().duration); 

        charging = false;
        explosionDuration = 0.6f;
        //distanceEffectLight.range = area;
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
        distance = transform.position + transform.forward + aboveGround;
        var distanceEffectPrefab = (Resources.Load("Characters/Bob/Abilities/ShadowRaze/ShadowRazeDistanceEffectSphere") as GameObject);
        distanceEffect = (GameObject)Instantiate(distanceEffectPrefab, distance, transform.rotation);
        //distanceEffectLight = distanceEffect.GetComponent<Light>();
        //distanceEffectLight.range = area;
        distanceEffect.transform.position = distance;
        maxDistance = transform.position + aboveGround + transform.forward * 10f;
    }

    // Use this for initialization
    void Awake () {
        Init();
		energyCost = 66f;
        area = 3f;
        speed = 12f;
        damage = 40f;
        explosionDuration = 0.6f;
        var distanceEffectPrefab = (Resources.Load("Characters/Bob/Abilities/ShadowRaze/ShadowRazeDistanceEffectSphere") as GameObject);


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
