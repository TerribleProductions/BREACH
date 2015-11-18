using UnityEngine;
using System.Collections;
/// <summary>
/// Class for modeling states. Should be treated as immutable, because it is.
/// </summary>
public struct StateEffect
{
    public StateEffect(CharacterState.States state, float duration)
    {
        this.state = state;
        this.duration = duration;
    }
    public CharacterState.States state {
        get; private set;
    }
    public float duration
    {
        get; private set;
    }

}

