using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "LaserSpell", menuName = "Spells/Shapes/LaserSpell")]
public class LaserSpell : Spell
{
    public float range = 10f;
    public Color laserColor = Color.white;
    
    public override void CastSpell()
    {
        shooter.Fire(this);
    }
}
