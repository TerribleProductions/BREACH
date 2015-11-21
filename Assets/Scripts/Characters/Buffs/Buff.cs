using UnityEngine;
using System.Collections;

public interface Buff {

    float duration { get; set; }

    void Apply(Character target);
    void Unapply(Character target);
}
