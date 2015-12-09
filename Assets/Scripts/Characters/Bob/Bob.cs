using UnityEngine;
using System.Collections;

public class Bob : Character {
	// Use this for initialization
	protected override void  Awake () {
        base.Awake();
        moveSpeed = 12f;

        maxEnergy = 100;
        maxHp = 100;
        energy = maxEnergy;
        energyRegeneration = 66f;

        var mainAbility = gameObject.AddComponent<ShotgunBlast>();
        var secondaryAbility = gameObject.AddComponent<ShadowRaze>();
        var movementAbility = gameObject.AddComponent<Dash>();
        var defensiveAbility = gameObject.AddComponent<DoubleTap>();

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
