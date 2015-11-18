using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class StateManager{

    public Character statefulChar;

    public StateEffect currentState {
        get; set;
    }

    public StateManager(Character c)
    {
        statefulChar = c;
    }
    /// <summary>
    /// Adds state if states precedence is equal to or higher than some other state in set of states. Filters out all states of lower precedence;
    /// </summary>
    /// <param name="state"></param>
    /// <returns>True if state was added, false if not</returns>
    public bool SetState(StateEffect state)
    {
        //Debug.Log("newState: " + state.state + ", currentState: " + currentState.state);
        bool canStateBeSet = CharacterState.CompareStates(state.state, currentState.state) > 0;
        //Debug.Log(canStateBeSet);
        if (canStateBeSet)
        {
            currentState = state;
        }
        return canStateBeSet;
    }


    public void Update(float deltaTime)
    {
        if(currentState.duration == Mathf.Infinity)
        {
            return;
        }

        float newDuration = currentState.duration - deltaTime;
        if (newDuration > 0)
        {
            currentState = new StateEffect(currentState.state, newDuration);
        }
        else
        {
            SetState(CharacterState.neutralState);
        }
        
    }

    public bool HasState(CharacterState.States state)
    {
        return currentState.state == state;
    }



}
