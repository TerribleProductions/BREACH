using UnityEngine;
using System.Collections;

public class Bob : Character {
	// Use this for initialization
	protected override void  Awake () {
        base.Awake();
        moveSpeed = 15f;

        maxEnergy = 100;
        energy = maxEnergy;
        energyRegeneration = 20f;

        var mainAbility = gameObject.AddComponent<DoubleTap>();
        var secondaryAbility = gameObject.AddComponent<AimMode>();
        var movementAbility = gameObject.AddComponent<Dash>();
        var defensiveAbility = gameObject.AddComponent<Reflect>();

        abilities = new CharAbilities(mainAbility, secondaryAbility, movementAbility, defensiveAbility);
	}

	
	// Update is called once per frame
	void FixedUpdate () {
        //Not sure if order matters here.
        stateManager.Update(Time.deltaTime);
        buffManager.Update(Time.deltaTime);
        moveInput();
        abilityInput();
        RegenEnergy();
        Turn();
	}
}
