using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "RaycastSpell", menuName = "Spells/RaycastSpell")]
public class RaycastSpell : Spell
{
    public float range = 10f;
    public int damage = 10;
    public float hitForce = 100f;
    public Color laserColor = Color.white;

    private RaycastSpellShooter rcShoot;

    public override void Initialize(GameObject caster)
    {
        rcShoot = caster.GetComponent<RaycastSpellShooter>();
        this.caster = caster.transform;

        rcShoot.spellDamage = damage;
        rcShoot.spellRange = range;
        rcShoot.hitForce = hitForce;
        rcShoot.laserLine.material = new Material(Shader.Find("Unlit/Color"));
        rcShoot.laserLine.material.color = laserColor;
    }

    public override void CastSpell()
    {
        rcShoot.Fire();
    }
}
