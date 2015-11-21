using UnityEngine;
using System.Collections;

public class Alice : Character {

    public int playerNumber = 1;
    // Use this for initialization
    protected override void Awake()
    {
        base.Awake();
        moveSpeed = 15f;

        var mainAbility = gameObject.AddComponent<RapidFire>();
        var secondaryAbility = gameObject.AddComponent<Quickshot>();
        controller = new ControlInterface(playerNumber);

        abilities = new CharAbilities(mainAbility, secondaryAbility, null);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        //Not sure if order matters here.
        stateManager.Update(Time.deltaTime);
        buffManager.Update(Time.deltaTime);
        moveInput();
        abilityInput();
    }
}
