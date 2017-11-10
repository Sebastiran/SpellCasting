using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Slow", menuName = "Spells/Components/Slow")]
public class Slow : Component
{
    public GameObject assemblyParticles;

    public override void ApplyEffect(CharacterStats stats)
    {
        stats.Slow(.7f, 4f);
    }

    public override void ApplyParticles(Vector3 position)
    {
        //throw new NotImplementedException();
    }

    public override void ApplyParticles(CharacterStats stats)
    {
        //throw new NotImplementedException();
    }

    public override GameObject GetAssemblyParticles()
    {
        return assemblyParticles;
    }

    public override float GetManaCost()
    {
        return 10f;
    }
}