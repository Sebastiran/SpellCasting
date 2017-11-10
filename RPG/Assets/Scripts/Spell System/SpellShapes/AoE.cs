using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AoE", menuName = "Spells/Shapes/AoE")]
public class AoE : Shape
{
    public float radius = 3f;
    public GameObject spellPrefab;

    public override void BeginCast(Spell spell)
    {
        throw new NotImplementedException();
    }

    public override float GetManaModifier()
    {
        return 1f;
    }

    public override float GetEffectModifier()
    {
        return 1f;
    }
}
