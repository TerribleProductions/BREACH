using UnityEngine;
using System.Collections;

public abstract class AbilityEffect : MonoBehaviour{

    public GameObject owner;
    public abstract Buff buff {get;  }
	
}
