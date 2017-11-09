using UnityEngine;

public class Component : ScriptableObject
{
    public virtual void ApplyComponentEffect(CharacterStats stats)
    {
        // This method is meant to be overwritten
    }
}