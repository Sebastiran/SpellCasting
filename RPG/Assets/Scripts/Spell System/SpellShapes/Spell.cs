using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : ScriptableObject
{
    new public string name = "New Name";
    public Sprite icon;
    public AudioClip sound;
    public float manaCost = 1f;
    public Component[] components;

    [HideInInspector] public Transform caster;
    protected SpellShooter shooter;

    public virtual void Initialize(GameObject caster)
    {
        this.caster = caster.transform;
        shooter = caster.GetComponent<SpellShooter>();
    }
    public virtual void CastSpell()
    {
    }

    // TODO
    // Remove the castprefabs on projectile and AoE. Add visual effects for each component and shape.
    // Build a spell (like a factory) using the visuals. This removes the need for a prefab and removes the need of making visuals for each individual spell.
}