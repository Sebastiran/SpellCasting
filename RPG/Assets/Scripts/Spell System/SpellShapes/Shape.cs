using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shape : ScriptableObject
{
    public abstract void BeginCast(Spell spell);    // Assemble the spell

    public abstract float GetManaModifier();        // Modifies the manacost of the components

    public abstract float GetEffectModifier();      // Modifies the effectiveness of the components and modifiers
}