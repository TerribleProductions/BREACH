using UnityEngine;
using System.Collections;
using System;

public abstract class Buff : IEquatable<Buff>
{

    public abstract string buffName { get; set; }
    public abstract float duration { get; set; }

    public abstract bool stackable { get; set; }

    public abstract void Apply(Character target);

    public bool Equals(Buff other)
    {
        return this.buffName.Equals(other.buffName);
    }

    public abstract void Unapply(Character target);

}
