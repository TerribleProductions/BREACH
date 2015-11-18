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
        MOVING = 0,
        BASIC_ATTACK = 1,
        SPECIAL_ATTACK = 2,
        IMMOBILE = 3,
        INACTIVE = 4,
        NEUTRAL //This can alwas be applied, but should never be explicitly be assigned
    }

    public static int CompareStates(States a, States b)
    {
        int dif = (int)a - (int)b;
        if(a == States.NEUTRAL || b == States.NEUTRAL)
        {
            return 1;
        }else if(a == b)
        {
            return 0;
        }

        return dif;
    }


}
