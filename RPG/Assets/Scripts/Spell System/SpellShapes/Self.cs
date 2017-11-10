using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Self", menuName = "Spells/Shapes/Self")]
public class Self : Shape
{
    public override void BeginCast(Spell spell)
    {
        Debug.Log("Casting self: " + spell.name);
        SpellHelper.instance.ApplySpellToEntity(spell.caster, spell);
        SpellHelper.instance.SpellHitEntity(spell.caster, spell);
    }

    public override float GetEffectModifier()
    {
        return 1f;
    }

    public override float GetManaModifier()
    {
        return 1f;
    }
}
