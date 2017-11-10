using System;
using UnityEngine;

[CreateAssetMenu(fileName = "MagicDamage", menuName = "Spells/Components/MagicDamage")]
public class MagicDamage : Component
{
    public GameObject assemblyParticles;

    public override void ApplyEffect(CharacterStats stats)
    {
        stats.TakeMagicDamage(5);
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
