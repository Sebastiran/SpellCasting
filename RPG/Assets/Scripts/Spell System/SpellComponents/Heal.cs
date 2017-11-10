using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Heal", menuName = "Spells/Components/Heal")]
public class Heal : Component
{
    public GameObject assemblyParticles;
    public GameObject hitParticles;

    public override void ApplyEffect(CharacterStats stats)
    {
        stats.Heal(10);
    }

    public override void ApplyParticles(Vector3 position)
    {
        if (hitParticles != null)
        {
            Instantiate(hitParticles, position, Quaternion.identity, null);
        }
    }

    public override void ApplyParticles(CharacterStats stats)
    {
        if (hitParticles != null)
        {
            Instantiate(hitParticles, stats.transform.position, Quaternion.identity, null);
        }
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