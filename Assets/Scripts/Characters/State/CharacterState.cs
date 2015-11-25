using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

public class State : IEquatable<State>
{
    public CharacterState.States[] precedenceList;
    private CharacterState.States state;
    public State(CharacterState.States state, params CharacterState.States[] precedence)
    {
        precedenceList = precedence;
        this.state = state;
    }

    public bool Equals(State other)
    {
        return state == other.state;
    }

    public bool HasPrecedence(State other)
    {
        return precedenceList.Contains(other.state);
    }

    public override string ToString()
    {
        return state.ToString();
    }
}

public static class CharacterState
{

    public static State NEUTRAL = new State(States.NEUTRAL, States.NEUTRAL, States.MOVING, States.PRE_ATTACK, States.BASIC_ATTACK, States.SPECIAL_ATTACK, States.IMMOBILE, States.INACTIVE, States.CHANNELING);
    public static State MOVING = new State(States.MOVING, States.NEUTRAL);
    public static State PRE_ATTACK = new State(States.PRE_ATTACK, States.NEUTRAL, States.MOVING);
    public static State BASIC_ATTACK = new State(States.BASIC_ATTACK, States.NEUTRAL, States.MOVING, States.PRE_ATTACK);
    public static State SPECIAL_ATTACK = new State(States.SPECIAL_ATTACK, States.NEUTRAL, States.MOVING, States.PRE_ATTACK, States.BASIC_ATTACK);
    public static State IMMOBILE = new State(States.IMMOBILE, States.NEUTRAL, States.MOVING, States.PRE_ATTACK, States.BASIC_ATTACK, States.SPECIAL_ATTACK, States.IMMOBILE);
    public static State INACTIVE = new State(States.INACTIVE, States.NEUTRAL, States.MOVING, States.PRE_ATTACK, States.BASIC_ATTACK, States.SPECIAL_ATTACK, States.IMMOBILE, States.INACTIVE);
    public static State CHANNELING = new State(States.CHANNELING, States.PRE_ATTACK, States.NEUTRAL, States.BASIC_ATTACK, States.SPECIAL_ATTACK, States.MOVING);


    public static StateEffect neutralStateEffect = new StateEffect(NEUTRAL, Mathf.Infinity, null, null, null);

    public enum States
    {
        NEUTRAL,
        MOVING,
        PRE_ATTACK, 
        BASIC_ATTACK,
        CHANNELING,
        SPECIAL_ATTACK,
        IMMOBILE,
        INACTIVE,
        
    }

}
