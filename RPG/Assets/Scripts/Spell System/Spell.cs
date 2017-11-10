using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSpell", menuName = "Spells/NewSpell")]
public class Spell : ScriptableObject
{
    new public string name = "New Name";
    public Sprite icon;
    public AudioClip sound;

    public Shape shape;
    public Component[] components;
    public Modifier[] modifiers;

    [HideInInspector] public CharacterStats caster;
    [HideInInspector] public Vector3 targetPosition;

    public void BeginCast(CharacterStats caster, Vector3 targetPosition)
    {
        this.caster = caster;
        this.targetPosition = targetPosition;

        shape.BeginCast(this);
    }

    // TODO
    // Remove the castprefabs on projectile and AoE. Add visual effects for each component and shape.
    // Build a spell (like a factory) using the visuals. This removes the need for a prefab and removes the need of making visuals for each individual spell.
}
