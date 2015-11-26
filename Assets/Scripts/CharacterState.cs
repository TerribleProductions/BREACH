using UnityEngine;
using System.Collections;



public static class CharacterState
{

    public static StateEffect neutralState = new StateEffect(CharacterState.States.NEUTRAL, Mathf.Infinity, null);

    /// <summary>
    /// The ordering of this enum decides precedence of the state
    /// </summary>
    public enum States
    {
        NEUTRAL,
        MOVING,
        PRE_ATTACK, 
        BASIC_ATTACK,
        SPECIAL_ATTACK,
        IMMOBILE,
        INACTIVE,
        
    }

    public static int CompareStates(States a, States b)
    {
        int aInt = (int)a;
        int bInt = (int)b;
        int dif = aInt - bInt;

        return dif;
    }


}
