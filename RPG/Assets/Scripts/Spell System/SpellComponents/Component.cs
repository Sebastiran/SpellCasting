using UnityEngine;

public abstract class Component : ScriptableObject
{
    // Apply the effect of the component to the character
    public abstract void ApplyEffect(CharacterStats stats);

    // Spawn the particles used when the spell hits an entity
    public abstract void ApplyParticles(CharacterStats stats);

    // Spawn the particles used when the spell hits the ground
    public abstract void ApplyParticles(Vector3 position);

    // Returns the particles used in the shape assembly
    public abstract GameObject GetAssemblyParticles();

    // Get the manacost of the component
    public abstract float GetManaCost();

    // TODO: Add a parameter in the SpawnApplyParticles function which allows for the Modifiers to change the looks of the particles
}