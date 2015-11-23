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
    public State state{ get; private set; }
    public float duration = Mathf.Infinity;

    public override string ToString()
    {
        return state.ToString();
    }

    /// <summary>
    /// Constructs a new statechain of in sequence a,b
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    private StateEffect(StateEffect a, StateEffect b) : this(a.state, a.duration, a.preEffect, a.duringEffect, a.postEffect)
    {
        this.nextState = b;
    }

    /// <summary>
    /// Constructor for stateeffect without effects...
    /// </summary>
    /// <param name="state"></param>
    /// <param name="duration"></param>
    public StateEffect(State state, float duration)
    {
        this.state = state;
        this.duration = duration;
    }


    public StateEffect(State state2, float duration, Callback preEffect, Callback duringEffect, Callback postEffect)
    {
        
        this.state = state2;
        this.duration = duration;
        this.preEffect = preEffect;
        this.duringEffect = duringEffect;
        this.postEffect = postEffect;
    }

    public static StateEffect operator +(StateEffect a, StateEffect b)
    {
        return new StateEffect(a, b);
    }



}

