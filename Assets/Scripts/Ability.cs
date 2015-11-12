using UnityEngine;
using System.Collections;

public interface Ability  {

    float globalCooldown { get; set; }
    float cooldown { get; set; }
    string abilityName { get; set; }
    string description { get; set; }

    //There should probably be some type variable that is an enum sort of like "projectile/self cast/passive etc.."

    void Cast();

	
	
}
