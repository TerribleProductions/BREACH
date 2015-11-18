using UnityEngine;
using System.Collections;
/// <summary>
/// Class for modeling states. Should be treated as immutable, because it is.
/// </summary>
public struct StateEffect
{
    public StateEffect(CharacterState.States state, float duration, Callback callback)
    {
        this.state = state;
        this.duration = duration;
        this.callback = callback;
    }

    public delegate void Callback();

    public Callback callback;
    public CharacterState.States state {
        get; private set;
    }
    public float duration
    {
        get; private set;
    }

}

