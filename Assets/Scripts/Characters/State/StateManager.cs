using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

public class StateManager{

    //Not sure this is needed
    public Character statefulChar;

    public StateEffect currentStateEffect = CharacterState.neutralStateEffect;

    public StateManager(Character c)
    {
        statefulChar = c;
    }
    /// <summary>
    /// Adds state if states precedence is equal to or higher than some other state in set of states. Filters out all states of lower precedence;
    /// </summary>
    /// <param name="state"></param>
    /// <returns>True if state was added, false if not</returns>
    public bool SetState(StateEffect stateEffect)
    {
        var canStateBeSet = stateEffect.state.HasPrecedence(currentStateEffect.state);
        if (canStateBeSet)
        {
            currentStateEffect = stateEffect;
            //Exececute effect that is at start of state.
            ExecuteEffect(currentStateEffect.preEffect);
            
            setFloatText();
        }
        return canStateBeSet;
    }

    public bool CanSetState(StateEffect stateEffect)
    {
        return stateEffect.state.HasPrecedence(currentStateEffect.state);
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
        if(currentStateEffect.duration == Mathf.Infinity)
        {
            ExecuteEffect(currentStateEffect.duringEffect);
            return;
        }

        float newDuration = currentStateEffect.duration - deltaTime;
        if (newDuration > 0)
        {
            currentStateEffect.duration = newDuration;
        }
        else
        {
            ExecuteEffect(currentStateEffect.postEffect);
            var nextState = currentStateEffect.nextState;
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
        
        if(statefulChar != null && currentStateEffect != null)
        {
            statefulChar.gameObject.GetComponent<TextMesh>().text = currentStateEffect.ToString();
        }
        
    }

    public void SetNeutralState()
    {
        SetState(CharacterState.neutralStateEffect);
    }


    public bool HasState(State state)
    {
        return currentStateEffect.state.Equals(state);
    }



}
