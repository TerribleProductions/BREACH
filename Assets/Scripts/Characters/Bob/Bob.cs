using UnityEngine;
using System.Collections;

public class Bob : Character {

	// Use this for initialization
	protected override void  Awake () {
        base.Awake();
        moveSpeed = 15f;
        var mainAbility = gameObject.AddComponent<DoubleTap>();
        var secondaryAbility = gameObject.AddComponent<Quickshot>();
        var defensiveAbility = gameObject.AddComponent<EnforcerKick>();

        abilities = new CharAbilities(mainAbility, secondaryAbility, defensiveAbility);
	}

	
	// Update is called once per frame
	void FixedUpdate () {

        moveInput();
        abilityInput();
        stateManager.Update(Time.deltaTime);
        Debug.Log(stateManager.currentState.state);
	
	}
}
