using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AoESpell", menuName = "Spells/Shapes/AoESpell")]
public class AoESpell : Spell
{
    public float radius = 3f;
    public GameObject spellPrefab;

    public override void CastSpell()
    {
        base.CastSpell();
        shooter.Fire(this);
    }
}
