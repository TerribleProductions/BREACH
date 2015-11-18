using UnityEngine;
using System.Collections;
using System.Linq;
/// <summary>
/// Class for modeling states. Should probably be an IEnumerable.
/// </summary>
public class StateEffect
{
    public StateEffect(CharacterState.States state, float duration, Callback callback)
    {
        this.state = state;
        this.duration = duration;
        this.callback = callback;
    }
    /// <summary>
    /// Constructs a new statechain of in sequence a,b
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    private StateEffect(StateEffect a, StateEffect b)
    {
        this.state = a.state;
        this.duration = a.duration;
        this.callback = a.callback;
        this.nextState = b;
    }
    /// <summary>
    /// Constructs a chain of states of arbitrary length
    /// </summary>
    /// <param name="states"></param>
    public StateEffect(params StateEffect[] states)
    {
        var head = states.First();
        //Folds over the tail to generate one long state chain
        var tailStates = states.Skip(2).Aggregate(states[1], (a, b) =>
        {
            return new StateEffect(a, b);
        });
        this.state = head.state;
        this.duration = head.duration;
        this.callback = head.callback;
        this.nextState = tailStates;
    }

    public static StateEffect operator +(StateEffect a, StateEffect b)
    {
        return new StateEffect(a, b);
    }

    public delegate void Callback();

    public Callback callback;

    public StateEffect nextState;
    public CharacterState.States state {
        get; private set;
    }
    public float duration
    {
        get; set;
    }

    public override string ToString()
    {
        return state.ToString();
    }

}

