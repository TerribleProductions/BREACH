using UnityEngine;
using System.Collections;

public class Bob : Character {
    //Unity cant serialize abstract classes so this is a temporary solution to this. Only this variable needs to be exposed, so its not a prio to fix.
    public int playerNumber = 1;
	// Use this for initialization
	protected override void  Awake () {
        base.Awake();
        moveSpeed = 15f;

        var mainAbility = gameObject.AddComponent<DoubleTap>();
        var secondaryAbility = gameObject.AddComponent<Quickshot>();
        var defensiveAbility = gameObject.AddComponent<EnforcerKick > ();
        controller = new ControlInterface(playerNumber);

        abilities = new CharAbilities(mainAbility, secondaryAbility, defensiveAbility);
	}

	
	// Update is called once per frame
	void FixedUpdate () {
        //Not sure if order matters here.
        Debug.Log(buffManager.buffs);
        stateManager.Update(Time.deltaTime);
        buffManager.Update(Time.deltaTime);
        moveInput();
        abilityInput();
	}
}
