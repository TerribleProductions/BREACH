using UnityEngine;
using System.Collections;

public class Alice : Character {


    // Use this for initialization
    protected override void Awake()
    {
        base.Awake();
        moveSpeed = 12f;
        maxEnergy = 100;
        energy = maxEnergy;
        energyRegeneration = 66f;
        maxHp = 100f;
        
        var mainAbility = gameObject.AddComponent<RapidFire>();
        var secondaryAbility = gameObject.AddComponent<Reflect>();
        var movementAbility = gameObject.AddComponent<Dash>();
        var defensiveAbility = gameObject.AddComponent<AimMode>();

        abilities = new CharAbilities(mainAbility, secondaryAbility, movementAbility, defensiveAbility);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RegenEnergy();
        //Not sure if order matters here.
        stateManager.Update(Time.deltaTime);
        buffManager.Update(Time.deltaTime);
        moveInput();
        abilityInput();
        Turn();
    }
}
