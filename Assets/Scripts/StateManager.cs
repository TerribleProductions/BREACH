using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

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
        if((int)state.state == 0)
        {
            throw new Exception("Cannot assign neutral state from here");
        }
        bool canStateBeSet = CharacterState.CompareStates(state.state, currentState.state) > 0;
        Debug.Log(CharacterState.CompareStates(state.state, currentState.state));
        if (canStateBeSet)
        {
            Debug.Log("Setting state to: " + state.state);
            currentState = state;
        }
        return canStateBeSet;
    }


    public void Update(float deltaTime)
    {
        Debug.Log("CurrentState: "+currentState.state);
        if(currentState.duration == Mathf.Infinity)
        {
            return;
        }

        float newDuration = currentState.duration - deltaTime;
        Debug.Log(newDuration);
        if (newDuration > 0)
        {
            currentState = new StateEffect(currentState.state, newDuration, currentState.callback);
        }
        else
        {
            if(currentState.callback != null)
            {
                Debug.Log("Calling callback");
                currentState.callback();
            }
            Debug.Log("asdf");
            SetNeutralState();
        }
        
    }

    public void SetNeutralState()
    {
        Debug.Log("Setting neutral state");
        currentState = CharacterState.neutralState;
    }


    public bool HasState(CharacterState.States state)
    {
        int a = CharacterState.CompareStates(state, currentState.state);
        return  a == 0;
    }



}
