using UnityEngine;
using System.Collections;

public abstract class Ability : MonoBehaviour {

    public float globalCooldown { get; set; }
    public float cooldown { get; set; }
    public string abilityName { get; set; }
    public string description { get; set; }

    //There should probably be some type variable that is an enum sort of like "projectile/self cast/passive etc.."

    public abstract void Cast();

    

	
	
}
