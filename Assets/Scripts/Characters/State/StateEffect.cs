using UnityEngine;
using System.Collections;
using System.Linq;
/// <summary>
/// Class for modeling states. Should probably be an IEnumerable(TODO?).
/// </summary>
public class StateEffect
{

    public delegate void Callback();

    public Callback postEffect = null;
    public Callback duringEffect = null;
    public Callback preEffect = null;

    public StateEffect nextState = null;
    public CharacterState.States state{ get; private set; }
    public float duration = Mathf.Infinity;

    public override string ToString()
    {
        return state.ToString();
    }

    /// <summary>
    /// Constructs a state effect that lasts until another state is applied
    /// </summary>
    /// <param name="state"></param>
    public StateEffect(CharacterState.States state)
    {
        this.state = state;
    }
    /// <summary>
    /// Constructs a state effect that lasts for some duration
    /// </summary>
    /// <param name="state"></param>
    /// <param name="duration"></param>
    public StateEffect(CharacterState.States state, float duration) : this(state)
    {
        this.duration = duration;
    }
    /// <summary>
    /// Constructs a single state effect containing a primitive state, a duration for the state, and a potential callback that is called at the end of the state.
    /// </summary>
    /// <param name="state">Primite state</param>
    /// <param name="duration">Duration of state.</param>
    /// <param name="callback">Function to be called at end of state</param>
    public StateEffect(CharacterState.States state, float duration, Callback postEffect) : this(state, duration)
    {
        this.postEffect = postEffect;
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
        this.postEffect = a.postEffect;
        this.nextState = b;
    }
    /// <summary>
    /// Constructs a chain of states of arbitrary length
    /// </summary>
    /// <param name="states"></param>
    public StateEffect(params StateEffect[] states)
    {
        //TODO: Actually test this
        var head = states.First();
        //Folds over the tail to generate one long state chain
        var tailStates = states.Skip(2).Aggregate(states[1], (a, b) =>
        {
            return a + b;
        });
        this.state = head.state;
        this.duration = head.duration;
        this.postEffect = head.postEffect;
        this.nextState = tailStates;
    }

    public StateEffect(CharacterState.States state, Callback postEffect) : this(state, Mathf.Infinity, postEffect)
    {

    }

    public StateEffect(CharacterState.States state, float duration, Callback postEffect, Callback duringEffect) : this(state, duration, postEffect)
    {
        this.duringEffect = duringEffect;
    }

    public StateEffect(CharacterState.States state, float duration, Callback preEffect, Callback duringEffect, Callback postEffect) : this(state, duration, preEffect, duringEffect)
    {
        this.postEffect = postEffect;
    }

    public static StateEffect operator +(StateEffect a, StateEffect b)
    {
        return new StateEffect(a, b);
    }



}

