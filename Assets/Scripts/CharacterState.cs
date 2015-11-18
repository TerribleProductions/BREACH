using UnityEngine;
using System.Collections;



public static class CharacterState
{

    public static StateEffect neutralState = new StateEffect(CharacterState.States.NEUTRAL, Mathf.Infinity);

    /// <summary>
    /// The ordering of this enum decides precedence of the state
    /// </summary>
    public enum States
    {
        
        MOVING,
        BASIC_ATTACK,
        SPECIAL_ATTACK,
        IMMOBILE,
        INACTIVE,
        NEUTRAL //This can alwas be applied, but should never be explicitly be assigned
    }

    public static int CompareStates(States a, States b)
    {
        Debug.Log((int)a - (int)b);
        if(a == States.NEUTRAL || b == States.NEUTRAL)
        {
            return 1;
        }
        
        return (int)a - (int)b;
    }


}
