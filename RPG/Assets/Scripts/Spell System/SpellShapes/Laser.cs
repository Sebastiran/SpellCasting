using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Laser", menuName = "Spells/Shapes/Laser")]
public class Laser : Shape
{
    public float range = 10f;
    public Color laserColor = Color.white;

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
