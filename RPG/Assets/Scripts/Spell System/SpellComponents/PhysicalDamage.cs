using UnityEngine;

[CreateAssetMenu(fileName = "PhysicalDamage", menuName = "Spells/Components/PhysicalDamage")]
public class PhysicalDamage : Component
{
    public override void ApplyComponentEffect(CharacterStats stats)
    {
        base.ApplyComponentEffect(stats);
        stats.TakeDamage(10);
    }
}