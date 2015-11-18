using UnityEngine;
using System.Collections;



public static class CharacterState
{
    //The neutral state. Is used a lot so it was useful to store it somewhere.
    public static StateEffect neutralState = new StateEffect(CharacterState.States.NEUTRAL);

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
    /// <summary>
    /// Compares the precedence between two states. If a has precedence over b, then it return >0, if lower less than 0, and if equal 0.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static int CompareStates(States a, States b)
    {
        int aInt = (int)a;
        int bInt = (int)b;
        int dif = aInt - bInt;

        return dif;
    }


}
