using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

public class StateManager{

    //Not sure this is needed
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
            throw new Exception("Cannot assign neutral state from here");//Just a safety measure to avoid screwing up state.
        }

        bool canStateBeSet = CharacterState.CompareStates(state.state, currentState.state) > 0;
        if (canStateBeSet)
        {
            currentState = state;
            //Exececute effect that is at start of state.
            ExecuteEffect(currentState.preEffect);
            
            setFloatText();
        }
        return canStateBeSet;
    }

    private void ExecuteEffect(StateEffect.Callback effect)
    {
        if(effect != null)
        {
            effect();
        }
    }

    /// <summary>
    /// Updates the duration of the current state. If another state is in the chain, it will swap the state to that, otherwise it reverts to neutral state.
    /// </summary>
    /// <param name="deltaTime">Time passed since last update</param>
    public void Update(float deltaTime)
    {
        //Ignore states without duration
        if(currentState.duration == Mathf.Infinity)
        {
            ExecuteEffect(currentState.duringEffect);
            return;
        }

        float newDuration = currentState.duration - deltaTime;
        if (newDuration > 0)
        {
            currentState.duration = newDuration;
        }
        else
        {
            ExecuteEffect(currentState.postEffect);
            var nextState = currentState.nextState;
            if (nextState != null)
            {
                //This does not allow for arbitrary precedence in state chains. Can be changed by allowing bypass in SetState
                SetState(nextState);
            }
            else
            { 
                SetNeutralState();
            }
            
        }
        
    }

    private void setFloatText()
    {
        
        if(statefulChar != null && currentState != null)
        {
            statefulChar.gameObject.GetComponent<TextMesh>().text = currentState.ToString();
        }
        
    }

    public void SetNeutralState()
    {
        currentState = CharacterState.neutralState;
        setFloatText();
    }


    public bool HasState(CharacterState.States state)
    {
        int a = CharacterState.CompareStates(state, currentState.state);
        return  a == 0;
    }



}
